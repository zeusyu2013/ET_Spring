using System;

namespace ET.Server
{
    [EntitySystemOf(typeof(UnitDBSaveComponent))]
    [FriendOfAttribute(typeof(ET.Server.UnitDBSaveComponent))]
    public static partial class UnitDBSaveComponentSystem
    {
        [Invoke(TimerInvokeType.UnitDBSaveTimer)]
        public class UnitDBSaveTimer : ATimer<UnitDBSaveComponent>
        {
            protected override void Run(UnitDBSaveComponent self)
            {
                try
                {
                    if (self.IsDisposed || self.Parent == null)
                    {
                        return;
                    }

                    self.SaveChanged();
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }
        }

        [EntitySystem]
        private static void Awake(this ET.Server.UnitDBSaveComponent self)
        {
            self.Timer = self.Root().GetComponent<TimerComponent>().NewRepeatedTimer(10 * 1000, TimerInvokeType.UnitDBSaveTimer, self);
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.UnitDBSaveComponent self)
        {
            self.Root().GetComponent<TimerComponent>().Remove(ref self.Timer);
        }

        public static void AddChange(this UnitDBSaveComponent self, Type type)
        {
            self.EntityChangeTypes.Add(type);
        }

        public static void AddChange(this UnitDBSaveComponent self, string collections)
        {
            
        }

        public static void SaveChanged(this UnitDBSaveComponent self)
        {
            if (self.EntityChangeTypes.Count < 1)
            {
                return;
            }

            Unit unit = self.GetParent<Unit>();
            Other2DBCache_AddOrUpdateUnitCache message = Other2DBCache_AddOrUpdateUnitCache.Create();
            message.UnitId = unit.Id;
            message.EntityTypes.Add(unit.GetType().FullName);
            message.EntityBytes.Add(unit.ToBson());

            foreach (Type type in self.EntityChangeTypes)
            {
                Entity entity = unit.GetComponent(type);
                if (entity == null || entity.IsDisposed)
                {
                    continue;
                }

                message.EntityTypes.Add(type.FullName);
                message.EntityBytes.Add(entity.ToBson());
            }

            self.EntityChangeTypes.Clear();

            StartSceneConfig config = StartSceneConfigCategory.Instance.DBCache;
            self.Root().GetComponent<ProcessInnerSender>().Send(config.ActorId, message);
        }
    }
}