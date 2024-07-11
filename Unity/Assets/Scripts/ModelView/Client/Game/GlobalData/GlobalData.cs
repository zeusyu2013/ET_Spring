using UnityEngine;

namespace ET.Client
{
    [Code]
    public class GlobalData : Singleton<GlobalData>, ISingletonAwake
    {
        public bool IsEditor
        {
            get;
            set;
        }

        public bool IsAndroid
        {
            get;
            set;
        }

        public bool IsiPhone
        {
            get;
            set;
        }

        public bool IsMobile
        {
            get;
            set;
        }

        public void Awake()
        {
            this.IsEditor =
#if UNITY_EDITOR
                    true;
#else
                    false;
#endif

            this.IsAndroid =
#if UNITY_ANDROID
                    true;
#else
                    false;
#endif

            this.IsiPhone =
#if UNITY_IOS
                    true;
#else
                    false;
#endif

            this.IsMobile = this.IsAndroid || this.IsiPhone;
        }
    }
}