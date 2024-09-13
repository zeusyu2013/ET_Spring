using System.IO;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public class SpriteAnimationEditorWindow : OdinMenuEditorWindow
    {
        [MenuItem("Tools/序列帧动画编辑器")]
        private static void OpenWindow()
        {
            var window = GetWindow<SpriteAnimationEditorWindow>();
            window.titleContent = new GUIContent("序列帧动画编辑器");
            window.Show();
        }

        private string _atlasPath = "Assets/Res/Unit/Atlas";

        private OdinMenuTree tree;

        [Button("生成")]
        public void Gen()
        {
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            this.tree ??= new OdinMenuTree(true);

            string[] directories = Directory.GetDirectories(this._atlasPath);
            if (directories.Length < 1)
            {
                return this.tree;
            }

            foreach (string directory in directories)
            {
                string roleName = Path.GetFileName(directory);
                string atlasFile = $"{directory}/{roleName}.asset";

                SpriteAnimationInfo info = null;
                if (File.Exists(atlasFile))
                {
                    info = AssetDatabase.LoadAssetAtPath<SpriteAnimationInfo>(atlasFile);
                }
                else
                {
                    info = CreateInstance<SpriteAnimationInfo>();
                    info.SpriteName = roleName;
                    AssetDatabase.CreateAsset(info, atlasFile);
                }

                this.tree.Add(roleName, info);
            }

            return this.tree;
        }
    }
}