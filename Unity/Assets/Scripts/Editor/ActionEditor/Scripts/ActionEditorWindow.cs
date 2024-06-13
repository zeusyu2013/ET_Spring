using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LitJson;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace ET
{
    [Serializable]
    public class ModelActionGroup
    {
        public string model;
        public List<ActionGroupData> action_groups;
    }

    [Serializable]
    public class ActionGroupData
    {
        public string action_group_name;
        public List<string> actions;
        public List<string> events;

        public List<ActionTrantionData> trantions;
        public List<ActionEventData> event_datas;
    }

    [Serializable]
    public class ActionTrantionData
    {
        public string action_from;
        public string action_to;
        public float fade_time;
    }

    [Serializable]
    public class ActionEventData
    {
        public string event_name;
        public float trigger_time;
    }

    public class ActionEditorWindow : OdinEditorWindow
    {
        [MenuItem("Tools/动作编辑器")]
        private static void ShowWindow()
        {
            var window = GetWindow<ActionEditorWindow>();
            window.titleContent = new GUIContent("动作编辑器");
            window.Show();
        }

        [LabelText("模型"), OnValueChanged("OnModelChanged")]
        public GameObject model;

        private GameObject _modelInScene;

        private void OnModelChanged()
        {
            if (this.model == null)
            {
                return;
            }

            this._modelInScene = Instantiate(model, Vector3.zero, Quaternion.identity);
            this._modelInScene.name = this.model.name;
            this._modelInScene.AddComponent<Animator>();

            FindModelAnimationClips();
        }
        
        [LabelText("动作集名称"), ValueDropdown("GetActionGroups")]
        public string actionGroupName;

        private IEnumerable GetActionGroups()
        {
            List<string> actionGroups = new();
            
            string modelActionGroupPath = string.Format(ModelActionGroupPath, this.model.name);
            if (!File.Exists(modelActionGroupPath))
            {
                return actionGroups;
            }

            string content = File.ReadAllText(modelActionGroupPath);
            if (string.IsNullOrEmpty(content))
            {
                return actionGroups;
            }

            ModelActionGroup modelActionGroup = JsonMapper.ToObject<ModelActionGroup>(content);
            if (modelActionGroup == null)
            {
                return actionGroups;
            }
            
            foreach (ActionGroupData actionGroupData in modelActionGroup.action_groups)
            {
                actionGroups.Add(actionGroupData.action_group_name);
            }

            return actionGroups;
        }

        [LabelText("动作"), ValueDropdown("GetActions")]
        public string action;

        private IEnumerable GetActions()
        {
            return _animationClipNames;
        }

        private GameObject _actionDirectorGo;
        private const string ActionPlayableAssetFolderPath = "Assets/Res/Unit/ActionPlayableAssets/{0}";
        private const string ActionPlayableAssetPath = "Assets/Res/Unit/ActionPlayableAssets/{0}/{1}.playable";

        [Button("\u271a"), ButtonGroup]
        private void AddClip()
        {
            if (string.IsNullOrEmpty(actionGroupName) || string.IsNullOrEmpty(action))
            {
                EditorHelper.LogError("动作集和动作切片名不能为空");
                return;
            }

            if (_actionDirectorGo == null)
            {
                return;
            }
            
            var director = this._actionDirectorGo.GetComponent<PlayableDirector>();
            if (director == null)
            {
                return;
            }

            TimelineAsset asset = director.playableAsset as TimelineAsset;
            if (asset == null)
            {
                return;
            }
            
            foreach (TrackAsset track in asset.GetOutputTracks())
            {
                if (track is not AnimationTrack _animationTrack)
                {
                    continue;
                }

                var animationClip = this._animtionClips.Find(x => x.name.Equals(action));
                if (animationClip == null)
                {
                    return;
                }

                TimelineClip clip = _animationTrack.CreateClip(animationClip);
                clip.start = track.duration;
            }
            
            AssetDatabase.Refresh();
        }

        [Button("\u25b6"), ButtonGroup]
        private void Preview()
        {
            if (string.IsNullOrEmpty(actionGroupName) || string.IsNullOrEmpty(action))
            {
                EditorHelper.LogError("动作集和动作切片名不能为空");
                return;
            }

            if (_actionDirectorGo == null)
            {
                this._actionDirectorGo = GameObject.Find("/ActionDirector");
            }

            if (this._actionDirectorGo == null)
            {
                this._actionDirectorGo = new GameObject("ActionDirector");
            }

            var director = this._actionDirectorGo.GetComponent<PlayableDirector>();
            if (director == null)
            {
                director = this._actionDirectorGo.AddComponent<PlayableDirector>();
            }

            director.playOnAwake = false;

            var playableAssetFolderPath = string.Format(ActionPlayableAssetFolderPath, this.model.name);
            if (!Directory.Exists(playableAssetFolderPath))
            {
                Directory.CreateDirectory(playableAssetFolderPath);
            }

            var playableAssetPath = string.Format(ActionPlayableAssetPath, this.model.name, this.actionGroupName);
            if (!File.Exists(playableAssetPath))
            {
                TimelineAsset timelineAsset = CreateInstance<TimelineAsset>();
                var animationClip = this._animtionClips.Find(x => x.name.Equals(action));
                if (animationClip == null)
                {
                    return;
                }

                timelineAsset.CreateTrack<AnimationTrack>("RoleAnimationTrack").CreateClip(animationClip);
                AssetDatabase.CreateAsset(timelineAsset, playableAssetPath);
            }

            var asset = AssetDatabase.LoadAssetAtPath<TimelineAsset>(playableAssetPath);
            director.playableAsset = asset;

            if (this._modelInScene != null)
            {
                var animator = this._modelInScene.GetComponent<Animator>();
                Bind(director, "RoleAnimationTrack", animator);
            }

            director.Play();
        }

        private const string ModelActionGroupFolderPath = "Assets/Bundles/Unit/{0}";
        private const string ModelActionGroupPath = "Assets/Bundles/Unit/{0}/ActionGroup.json";

        [Button("保存动作集")]
        private void Save()
        {
            if (_actionDirectorGo == null)
            {
                return;
            }

            PlayableDirector director = this._actionDirectorGo.GetComponent<PlayableDirector>();
            if (director == null)
            {
                return;
            }

            TimelineAsset asset = director.playableAsset as TimelineAsset;
            if (asset == null)
            {
                return;
            }

            string folder = string.Format(ModelActionGroupFolderPath, this.model.name);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string path = string.Format(ModelActionGroupPath, this.model.name);
            if (!File.Exists(path))
            {
                File.WriteAllText(path, "");
            }

            string content = File.ReadAllText(path);
            if (string.IsNullOrEmpty(content))
            {
                ModelActionGroup tempGroup = new();
                tempGroup.model = this.model.name;
                tempGroup.action_groups = new();
                content = JsonMapper.ToJson(tempGroup);
                File.WriteAllText(path, content);
            }

            ModelActionGroup modelActionGroup = JsonMapper.ToObject<ModelActionGroup>(content);
            var group = modelActionGroup.action_groups.Find(x => x.action_group_name.Equals(this.actionGroupName));
            if (group == null)
            {
                ActionGroupData actionGroupData = new()
                {
                    action_group_name = this.actionGroupName,
                    actions = new(),
                    events = new(),
                    trantions = new(),
                    event_datas = new()
                };

                FindElements(ref actionGroupData.actions, ref actionGroupData.events, ref actionGroupData.trantions);
                modelActionGroup.action_groups.Add(actionGroupData);
            }
            else
            {
                group.actions = new();
                group.events = new();
                group.trantions = new();
                group.event_datas = new();
            }

            content = JsonMapper.ToJson(modelActionGroup);
            File.WriteAllText(path, content);
        }

        private void Bind(PlayableDirector director, string trackName, UnityEngine.Object o)
        {
            TimelineAsset asset = director.playableAsset as TimelineAsset;
            if (asset == null)
            {
                return;
            }

            foreach (TrackAsset track in asset.GetOutputTracks())
            {
                if (!track.name.Equals(trackName))
                {
                    continue;
                }

                switch (track)
                {
                    case AnimationTrack _:
                    {
                        if (o is Animator)
                        {
                            director.SetGenericBinding(track, o);
                        }

                        return;
                    }
                }
            }
        }

        private void FindElements(ref List<string> actions, ref List<string> events, ref List<ActionTrantionData> trantions)
        {
            if (_actionDirectorGo == null)
            {
                return;
            }

            PlayableDirector director = this._actionDirectorGo.GetComponent<PlayableDirector>();
            if (director == null)
            {
                return;
            }

            TimelineAsset asset = director.playableAsset as TimelineAsset;
            if (asset == null)
            {
                return;
            }

            foreach (TrackAsset track in asset.GetOutputTracks())
            {
                switch (track)
                {
                    case AnimationTrack animationTrack:
                    {
                        foreach (TimelineClip timelineClip in animationTrack.GetClips())
                        {
                            actions.Add(timelineClip.animationClip.name);
                            trantions.Add(new ActionTrantionData()
                            {
                                action_from = timelineClip.animationClip.name,
                                action_to = "",
                                fade_time = (float)timelineClip.clipIn
                            });
                        }
                    }
                        break;
                }
            }
        }

        private const string AnimationClipPath = "Assets/Res/Unit/{0}/Animations";
        private List<string> _animationClipNames = new();
        private List<AnimationClip> _animtionClips = new();

        private void FindModelAnimationClips()
        {
            _animationClipNames.Clear();
            _animtionClips.Clear();

            if (this.model == null)
            {
                return;
            }

            string modelName = this.model.name;
            if (string.IsNullOrEmpty(modelName))
            {
                return;
            }

            string path = string.Format(AnimationClipPath, modelName);
            if (!Directory.Exists(path))
            {
                return;
            }

            var animations = Directory.GetFiles(path, "*.fbx");
            if (animations.Length < 1)
            {
                return;
            }

            foreach (string animationName in animations)
            {
                _animationClipNames.Add(Path.GetFileNameWithoutExtension(animationName));
            }

            string clipsPath = string.Format(AnimationEditorWindow.AnimationClipsBundlePath, modelName);
            if (!Directory.Exists(clipsPath))
            {
                return;
            }

            var anims = Directory.GetFiles(clipsPath, "*.anim");
            foreach (string anim in anims)
            {
                var clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(anim);
                if (clip == null)
                {
                    continue;
                }

                this._animtionClips.Add(clip);
            }
        }
    }
}