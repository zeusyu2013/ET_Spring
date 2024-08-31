using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(HatredComponent))]
    [FriendOfAttribute(typeof(ET.Server.HatredComponent))]
    public static partial class HatredComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.HatredComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.HatredComponent self)
        {
            self.Hatreds.Clear();
        }

        public static void IncHatred(this HatredComponent self, long unitId, long hatred)
        {
            if (unitId < 1)
            {
                return;
            }

            if (!self.Hatreds.TryAdd(unitId, hatred))
            {
                self.Hatreds[unitId] += hatred;
            }
        }

        public static Dictionary<long, long> ToMessage(this HatredComponent self)
        {
            return self.Hatreds;
        }

        public static void Clear(this HatredComponent self)
        {
            self.Hatreds.Clear();
        }
    }
}