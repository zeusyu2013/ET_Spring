namespace ET.Client
{
    [EntitySystemOf(typeof(SoundComponent))]
    public static partial class SoundComponentSystem
    {
        private static void Awake(this SoundComponent self)
        {
        }

        public static void PlaySound(this SoundComponent self, string eventName)
        {
        }

        public static void StopSound(this SoundComponent self, string eventName)
        {
        }
    }
}