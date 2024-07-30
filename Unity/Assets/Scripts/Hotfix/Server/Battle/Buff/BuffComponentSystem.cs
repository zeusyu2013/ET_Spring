using System;

namespace ET.Server
{
    [EntitySystemOf(typeof(BuffComponent))]
    [FriendOfAttribute(typeof(ET.Server.BuffComponent))]
    [FriendOfAttribute(typeof(ET.Server.Buff))]
    [FriendOfAttribute(typeof(ET.Server.BuffCreateInfo))]
    public static partial class BuffComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.BuffComponent self)
        {
            self.AddComponent<BuffTempComponent>();
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.BuffComponent self)
        {
            self.Buffs.Clear();
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.BuffComponent self)
        {
            self.AddComponent<BuffTempComponent>();

            foreach (Entity entity in self.Children.Values)
            {
                Buff buff = (Buff)entity;
                self.Buffs.Add(buff.ConfigId, buff);
            }
        }

        public static BuffCreateInfo Create(this BuffComponent self, int configId)
        {
            return self.GetComponent<BuffTempComponent>().AddChild<BuffCreateInfo, int>(configId);
        }

        public static bool CreateAndAdd(this BuffComponent self, int configId)
        {
            using (BuffCreateInfo info = self.Create(configId))
            {
                return self.Add(info);
            }
        }

        public static bool Add(this BuffComponent self, BuffCreateInfo info)
        {
            if (info == null || info.IsDisposed)
            {
                return false;
            }

            if (self == null || self.IsDisposed)
            {
                return false;
            }

            Buff buff = self.AddChild<Buff, int>(info.ConfigId);
            buff.Owner = self.GetParent<Unit>();

            Unit buffOwner = buff.Owner;
            if (buffOwner == null)
            {
                buff.Dispose();
                return false;
            }

            int configId = buff.ConfigId;
            if (self.Buffs.ContainsKey(buff.ConfigId))
            {
                // todo 有相同buff 待处理

                Buff temp = self.Buffs[configId];
                self.Remove(temp.Id);
            }

            self.Buffs.Add(configId, buff);

            M2C_BuffAdd m2CBuffAdd = M2C_BuffAdd.Create();
            m2CBuffAdd.UnitId = buffOwner.Id;
            m2CBuffAdd.BuffInfo = buff.ToMessage();
            BattleMessageHelper.SendClient(buffOwner, m2CBuffAdd, buff.Config.NotifyType);

            buff.AddActions();

            return true;
        }

        public static void Remove(this BuffComponent self, long buffId)
        {
            if (!self.Children.TryGetValue(buffId, out Entity entity))
            {
                return;
            }

            Buff buff = entity as Buff;

            try
            {
                self.Buffs.Remove(buff.ConfigId);

                M2C_BuffRemove m2CBuffRemove = M2C_BuffRemove.Create();
                Unit owner = buff.Owner;
                m2CBuffRemove.UnitId = owner.Id;
                m2CBuffRemove.BuffId = buff.Id;
                BattleMessageHelper.SendClient(owner, m2CBuffRemove, buff.Config.NotifyType);

                buff.RemoveActions();

                buff.Dispose();
            }
            catch (Exception e)
            {
                Log.Error($"Buff移除失败，BuffComponent {self.Id} buffId {buff.Id} buffConfigId {buff.Config?.Id ?? 0}, {e}");
            }
        }
    }
}