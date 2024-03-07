using UnityEditor;

namespace ET
{
    public static class EditorHelper
    {
        public static void Log(string msg)
        {
            EditorUtility.DisplayDialog("提示", msg, "好的");
        }
        
        public static void LogWarning(string msg)
        {
            EditorUtility.DisplayDialog("警告", msg, "好的");
        }
        
        public static void LogError(string msg)
        {
            EditorUtility.DisplayDialog("错误", msg, "好的");
        }
    }
}