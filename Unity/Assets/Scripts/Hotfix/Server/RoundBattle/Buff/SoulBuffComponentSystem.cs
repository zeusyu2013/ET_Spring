using System;

namespace ET.Server
{
    [EntitySystemOf(typeof(SoulBuffComponent))]
    [FriendOfAttribute(typeof(ET.Server.SoulBuffComponent))]
    [FriendOfAttribute(typeof(ET.Server.SoulBuff))]
    public static partial class SoulBuffComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulBuffComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulBuffComponent self)
        {
            self.Buffs.Clear();
        }

        public static int Create(this ET.Server.SoulBuffComponent self, int configId)
        {
            Soul soul = self.GetParent<Soul>();
            if (soul == null || soul.IsDisposed)
            {
                return ErrorCode.ERR_SoulBuffOwnerIsNull;
            }
            
            SoulBuff buff = self.AddChild<SoulBuff, int>(configId);
            buff.Owner = self.GetParent<Soul>();
            
            if (self.Buffs.ContainsKey(configId))
            {
                SoulBuff temp = self.Buffs[configId];
                self.RemoveBuff(temp.Id);
            }
            
            self.Buffs.Add(configId, buff);
            
            buff.AddActions();

            return ErrorCode.ERR_Success;
        }

        private static void RemoveBuff(this SoulBuffComponent self, long buffId)
        {
            if (!self.Children.TryGetValue(buffId, out Entity entity))
            {
                return;
            }
            
            SoulBuff buff = entity as SoulBuff;

            try
            {
                self.Buffs.Remove(buff.ConfigId);
                
                buff.RemoveActions();
                
                buff.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}