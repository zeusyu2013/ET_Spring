using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

namespace ET
{
    [CustomEditor(typeof(SpriteRenderer))]
    public class SpriteRendererInspector : Editor
    {
        private SpriteRenderer spriteRenderer;
        private ShadowCastingMode shadowCastingMode = ShadowCastingMode.Off;

        private void OnEnable()
        {
            spriteRenderer = target as SpriteRenderer;
            if (spriteRenderer == null)
            {
                return;
            }
        }

        public override void OnInspectorGUI()
        {
            var type = typeof(EditorApplication).Assembly.GetType("UnityEditor.SpriteRendererEditor");
            if (type == null)
            {
                return;
            }

            var editor = CreateEditor(target, type);
            editor?.OnInspectorGUI();

            using (new EditorGUILayout.HorizontalScope())
            {
                EditorGUILayout.LabelField("Sprite Cast Shadow");
                shadowCastingMode = (ShadowCastingMode)EditorGUILayout.EnumPopup(spriteRenderer?.shadowCastingMode);
                spriteRenderer.shadowCastingMode = shadowCastingMode;
            }
        }
    }
}