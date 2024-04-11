using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Cinemachine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace ET
{
    public class PathEditorWindow : OdinEditorWindow
    {
        [LabelText("场景："), ValueDropdown("OnSceneNames")]
        public string SceneName;

        private List<string> _sceneNames = new();
        private const string SceneResourcePath = "Assets/Bundles/Scenes";
        private UnityEngine.SceneManagement.Scene _scene;

        private IEnumerable OnSceneNames()
        {
            _sceneNames.Clear();

            var files = Directory.GetFiles(SceneResourcePath, "*.unity");
            if (files.Length < 1)
            {
                return _sceneNames;
            }

            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                _sceneNames.Add(fileName);
            }

            return _sceneNames;
        }

        private bool _isOpenScene = false;

        [Button("打开场景")]
        private void OpenScene()
        {
            if (string.IsNullOrEmpty(this.SceneName))
            {
                EditorHelper.LogError("请先选择场景");
                return;
            }

            var sceneFile = $"{SceneResourcePath}/{this.SceneName}.unity";
            if (!File.Exists(sceneFile))
            {
                EditorHelper.LogError($"{this.SceneName} 该场景文件不存在");

                return;
            }

            _scene = EditorSceneManager.OpenScene(sceneFile, OpenSceneMode.Single);

            _isOpenScene = true;

            this.LoadPathConfig();
        }

        [LabelText("路径编号")]
        public string AddPathId = "";

        [Button("新增")]
        private void AddPath()
        {
            GameObject root = GameObject.Find("/PathRoot");
            if (root == null)
            {
                root = new("PathRoot");
            }

            for (int i = 0; i < root.transform.childCount; i++)
            {
                var child = root.transform.GetChild(i);
                if (child.name.Equals(this.AddPathId))
                {
                    EditorHelper.LogError("路径编号重复");
                    return;
                }
            }

            GameObject pathGo = new(this.AddPathId);
            pathGo.transform.parent = root.transform;
            pathGo.transform.localPosition = Vector3.zero;

            GameObject dollyCartGo = new("DollyCart");
            dollyCartGo.transform.parent = pathGo.transform;
            CinemachineDollyCart dollyCart = dollyCartGo.AddComponent<CinemachineDollyCart>();

            GameObject dollyTrackGo = new("DollyTrack");
            dollyTrackGo.transform.parent = pathGo.transform;
            CinemachineSmoothPath path = dollyTrackGo.AddComponent<CinemachineSmoothPath>();

            dollyCart.m_Path = path;
        }

        [Button("保存寻路数据")]
        private void SavePathConfig()
        {
            if (!_isOpenScene)
            {
                EditorHelper.LogError("请先打开场景");
                return;
            }

            GameObject root = GameObject.Find("/PathRoot");
            if (root == null)
            {
                return;
            }

            List<PathInfo> pathInfos = new();
            for (int i = 0; i < root.transform.childCount; i++)
            {
                PathInfo info = new();

                var pathTransform = root.transform.GetChild(i);
                var pathId = int.Parse(pathTransform.name);
                if (pathId < 1)
                {
                    continue;
                }

                info.PathId = pathId;

                CinemachineSmoothPath path = pathTransform.Find("DollyTrack").gameObject.GetComponent<CinemachineSmoothPath>();
                if (path == null)
                {
                    continue;
                }

                info.Paths = new();
                foreach (CinemachineSmoothPath.Waypoint waypoint in path.m_Waypoints)
                {
                    Vector3 waypointPosition = waypoint.position;
                    this.RecalcHeight(ref waypointPosition);
                    info.Paths.Add(waypointPosition);
                }

                pathInfos.Add(info);
            }

            string jsonContent = LitJson.JsonMapper.ToJson(pathInfos);
            if (string.IsNullOrEmpty(jsonContent))
            {
                return;
            }

            var pathConfigPath = $"../Config/Json/s/Path/{this.SceneName}.json";
            if (File.Exists(pathConfigPath))
            {
                File.Delete(pathConfigPath);
            }

            File.WriteAllText(pathConfigPath, jsonContent);
        }

        public class PathInfo
        {
            public int PathId;
            public List<Vector3> Paths;
        }

        private void LoadPathConfig()
        {
            var pathConfigPath = $"../Config/Json/s/Path/{this.SceneName}.json";
            if (!File.Exists(pathConfigPath))
            {
                return;
            }

            var paths = LitJson.JsonMapper.ToObject<List<PathInfo>>(File.ReadAllText(pathConfigPath));
            if (paths.Count < 1)
            {
                return;
            }

            foreach (PathInfo pathInfo in paths)
            {
                CreatePathInScene(pathInfo);
            }
        }

        private void CreatePathInScene(PathInfo info)
        {
            GameObject root = GameObject.Find("/PathRoot");
            if (root == null)
            {
                root = new GameObject("PathRoot");
            }

            Transform pathTransform = root.transform.Find(info.PathId.ToString());
            if (pathTransform != null)
            {
                EditorHelper.LogError($"{info.PathId} 该路线已存在");
                return;
            }

            GameObject pathGo = new(info.PathId.ToString());
            pathGo.transform.parent = root.transform;
            
            GameObject dollyCartGo = new("DollyCart");
            dollyCartGo.transform.parent = pathGo.transform;
            CinemachineDollyCart dollyCart = dollyCartGo.AddComponent<CinemachineDollyCart>();

            GameObject dollyTrackGo = new("DollyTrack");
            dollyTrackGo.transform.parent = pathGo.transform;
            CinemachineSmoothPath path = dollyTrackGo.AddComponent<CinemachineSmoothPath>();

            List<CinemachineSmoothPath.Waypoint> waypoints = new();
            foreach (Vector3 infoPath in info.Paths)
            {
                CinemachineSmoothPath.Waypoint waypoint = new();
                waypoint.position = infoPath;
                this.RecalcHeight(ref waypoint.position);
                waypoints.Add(waypoint);
            }

            path.m_Waypoints = waypoints.ToArray();

            dollyCart.m_Path = path;
        }

        private void RecalcHeight(ref Vector3 position)
        {
            Ray ray = new();
            RaycastHit hit;
            ray.origin = new Vector3(position.x, 1000, position.z);
            ray.direction = Vector3.down;
            if (!Physics.Raycast(ray, out hit, 2000.0f, LayerMask.GetMask("Ground")))
            {
                return;
            }

            position.y = hit.point.y;
        }
    }
}