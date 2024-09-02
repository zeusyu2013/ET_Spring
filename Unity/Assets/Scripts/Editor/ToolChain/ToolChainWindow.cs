﻿using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public class ToolChainWindow : OdinMenuEditorWindow
    {
        private OdinMenuTree tree;

        [MenuItem("Tools/ToolChain")]
        private static void ShowWindow()
        {
            var window = GetWindow<ToolChainWindow>();
            window.titleContent = new GUIContent("工具链");
            window.minSize = new Vector2(580, 600);
            window.maximized = true;
            window.Show();
        }

        protected override OdinMenuTree BuildMenuTree()
        {
            if (tree != null)
            {
                return this.tree;
            }

            this.tree = new OdinMenuTree
            {
                { "卡通预设相关", CreateInstance<PrefabEditor>() },
                { "角色预设生成", CreateInstance<PrefabEditorWindow>() },
                { "动画相关", CreateInstance<AnimationEditorWindow>() },
                { "路径编辑器", CreateInstance<PathEditorWindow>() },
                { "Shader变体合并工具", CreateInstance<ShaderVariantsCollectionMergeWindow>() }
            };

            return this.tree;
        }
    }
}