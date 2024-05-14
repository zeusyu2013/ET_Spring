using System;
namespace ET.Server
{
    [EntitySystemOf(typeof(UnitCacheEventComponent))]
    [FriendOf(typeof(UnitCacheEventComponent))]
    public static partial class UnitCacheEventComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.UnitCacheEventComponent self)
        {
            var uiEvents = CodeTypes.Instance.GetTypes(typeof (IUnitCache));
            foreach (Type type in uiEvents)
            {
                object[] attrs = type.GetCustomAttributes(typeof (IUnitCache), false);
                if (attrs.Length == 0)
                {
                    continue;
                }
                UnitCacheEventAttribute cacheEventAttribute = attrs[0] as UnitCacheEventAttribute;
                
                self.CollectionNames.Add(cacheEventAttribute.Type.FullName);
            }
        }
    }
}

