using UnityEngine;

namespace ET
{
    public static partial class Util
    {
        public static void Active(this GameObject go, bool enable)
        {
            go.transform.localScale = enable ? Vector3.one : Vector3.zero;
        }
    }
}