using Animancer;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public class PrefabEditorWindow : OdinEditorWindow
    {
        [LabelText("预设名")]
        public string prefabName;

        [LabelText("模型")]
        public GameObject fbx;

        [LabelText("是否是主角")]
        public bool isRole;

        private const string PrefabPath = "Assets/Bundles/Unit";

        [Button("生成预设")]
        private void GenPrefab()
        {
            if (fbx == null)
            {
                return;
            }

            string prefabFilePath = $"{PrefabPath}/{prefabName}.prefab";

            GameObject temp = GameObject.Find($"/{prefabName}");
            if (temp != null)
            {
                GameObject.DestroyImmediate(temp);
            }

            GameObject go = new(prefabName);

            PrefabUtility.SaveAsPrefabAsset(go, prefabFilePath);

            GameObject fbxGo = UnityEngine.Object.Instantiate(fbx, go.transform, true);
            fbxGo.name = this.fbx.name;

            // 设置模型
            ReferenceCollector collector = go.AddComponent<ReferenceCollector>();
            collector.Add("Model", fbxGo);

            // 设置相机焦点
            if (isRole)
            {
                GameObject cameraLookAt = new("CameraLookAt");
                cameraLookAt.transform.SetParent(go.transform);
                cameraLookAt.transform.localPosition = new Vector3(0, 2, 0);

                collector.Add("CameraLookAt", cameraLookAt);
            }

            // 设置碰撞检测发射点
            GameObject rayPoint = new("RayPoint");
            rayPoint.transform.SetParent(go.transform);
            rayPoint.transform.localPosition = new Vector3(0, 2, 0);

            collector.Add("RayPoint", rayPoint);

            // 设置动画组件
            Animator animator = fbxGo.GetComponent<Animator>();
            if (animator == null)
            {
                animator = fbxGo.AddComponent<Animator>();
            }

            animator.applyRootMotion = false;
            collector.Add("Animator", animator);

            AnimancerComponent animancer = fbxGo.AddComponent<AnimancerComponent>();
            collector.Add("AnimancerComponent", animancer);

            // 设置角色控制器
            CharacterController characterController = go.AddComponent<CharacterController>();
            characterController.center = new Vector3(0, 1, 0);
            collector.Add("CharacterController", characterController);

            // 设置层级
            go.layer = LayerMask.NameToLayer("Unit");

            PrefabUtility.SaveAsPrefabAsset(go, prefabFilePath);
        }
    }
}