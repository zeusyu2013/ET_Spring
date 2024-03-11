using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public class AnimationEditorWindow : OdinEditorWindow
    {
        [BoxGroup("导出"), LabelText("动画Fbx路径"), FolderPath]
        public string AnimationPath;

        [BoxGroup("导出"), Button("导出切片")]
        public void ExportAnimationClips()
        {
            if (string.IsNullOrEmpty(AnimationPath))
            {
                EditorHelper.LogError("路径为空");
                return;
            }

            ForeachDirectory(AnimationPath);
            
            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        }

        [BoxGroup("压缩"), LabelText("单个切片还是目录批量")]
        public bool SingleOrBatch = true;
        
        [BoxGroup("压缩"), LabelText("动画切片"), ShowIf("@SingleOrBatch == true")]
        public AnimationClip AnimationClip;
        
        [BoxGroup("压缩"), LabelText("动画切片目录"), FolderPath, ShowIf("@SingleOrBatch == false")]
        public string AnimationClipsPath;
        
        [BoxGroup("压缩"), Button("压缩切片")]
        public void CompressionClips()
        {
            if (this.SingleOrBatch)
            {
                if (this.AnimationClip == null)
                {
                    EditorHelper.LogError("请设置压缩切片");
                    return;
                }
            
                CompressAnimationClip(this.AnimationClip);
            }
            else
            {
                if (string.IsNullOrEmpty(this.AnimationClipsPath))
                {
                    EditorHelper.LogError("请设置压缩切片目录");
                    return;
                }

                var files = Directory.GetFiles(this.AnimationClipsPath, "*.anim");
                foreach (string file in files)
                {
                    AnimationClip clip = AssetDatabase.LoadAssetAtPath<AnimationClip>(file);
                    if (clip == null)
                    {
                        continue;
                    }
                    
                    CompressAnimationClip(clip);
                }
            }
            
            EditorHelper.Log("压缩完成");
        }

        private void ForeachDirectory(string dir)
        {
            if (!Directory.Exists(dir))
            {
                EditorHelper.LogError("请设置正确路径");
                return;
            }

            var files = Directory.GetFiles(dir, "*.fbx");
            foreach (var file in files)
            {
                if (Directory.Exists(file))
                {
                    ForeachDirectory(file);
                }
                else
                {
                    var fbxPath = file.ToLower();
                    var clips = AssetDatabase.LoadAllAssetsAtPath(fbxPath);
                    if (clips == null || clips.Length < 1)
                    {
                        continue;
                    }

                    fbxPath = fbxPath.Replace("/", "\\");
                    var parentFolder = fbxPath.Split('\\')[4];
                    foreach (var clip in clips)
                    {
                        if (!(clip is AnimationClip animationClip))
                        {
                            continue;
                        }

                        if (animationClip.name.StartsWith("__preview__"))
                        {
                            continue;
                        }

                        CreateAnimationClip(animationClip, parentFolder);
                    }
                }
            }
        }

        private void CreateAnimationClip(AnimationClip clip, string parentFolder)
        {
            var temp = new AnimationClip();
            EditorUtility.CopySerialized(clip, temp);
            RemoveAnimationClipScale(temp);
            CompressAnimationClip(temp);
            OptimizeConstantCurves(temp);

            var folder = $"{Application.dataPath}/Bundles/Animations/{parentFolder}";
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            EditorHelper.CreateAsset(temp, $"{folder}/{clip.name}.anim");
            EditorHelper.SaveAsset(temp);
        }

        private void RemoveAnimationClipScale(AnimationClip clip)
        {
            var binding = AnimationUtility.GetCurveBindings(clip);
            foreach (var curveBinding in binding)
            {
                var name = curveBinding.propertyName.ToLower();
                if (name.Contains("scale"))
                {
                    AnimationUtility.SetEditorCurve(clip, curveBinding, null);
                }
            }
        }

        private void CompressAnimationClip(AnimationClip clip)
        {
            var curveBindings = AnimationUtility.GetCurveBindings(clip);
            foreach (var cData in curveBindings)
            {
                var data = AnimationUtility.GetEditorCurve(clip, cData);

                if (data?.keys == null)
                {
                    continue;
                }

                var keyframes = data.keys;
                for (var i = 0; i < keyframes.Length; i++)
                {
                    var key = keyframes[i];
                    key.value = float.Parse(key.value.ToString("f3"));
                    key.inTangent = float.Parse(key.inTangent.ToString("f3"));
                    key.outTangent = float.Parse(key.outTangent.ToString("f3"));
                    key.inWeight = float.Parse(key.inWeight.ToString("f3"));
                    key.outWeight = float.Parse(key.outWeight.ToString("f3"));
                    keyframes[i] = key;
                }

                data.keys = keyframes;
                clip.SetCurve(cData.path, cData.type, cData.propertyName, data);
            }
        }

        private void OptimizeConstantCurves(AnimationClip clip)
        {
            var binds = AnimationUtility.GetCurveBindings(clip);
            foreach (var bind in binds)
            {
                var curve = AnimationUtility.GetEditorCurve(clip, bind);
                var keys = curve.keys;
                var beginIndex = -1;
                List<int> removeIndexes = new List<int>();

                for (int i = 0; i < keys.Length; i++)
                {
                    var keyFrame = keys[i];
                    if ((float.IsInfinity(keyFrame.inTangent) && float.IsInfinity(keyFrame.outTangent)) ||
                        (Mathf.Abs(keyFrame.inTangent) <= float.Epsilon &&
                            Mathf.Abs(keyFrame.outTangent) <= float.Epsilon))
                    {
                        removeIndexes.Add(i);
                    }
                }

                for (int i = removeIndexes.Count - 1; i >= 0; i--)
                {
                    curve.RemoveKey(removeIndexes[i]);
                }

                if (curve.length == 0)
                {
                    AnimationUtility.SetEditorCurve(clip, bind, null);
                }
                else
                {
                    AnimationUtility.SetEditorCurve(clip, bind, curve);
                }
            }

            EditorHelper.SaveAsset(clip);
        }
    }
}