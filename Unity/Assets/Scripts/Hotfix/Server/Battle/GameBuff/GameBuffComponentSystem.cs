using System;

namespace ET.Server
{
    [EntitySystemOf(typeof(GameBuffComponent))]
    [FriendOfAttribute(typeof(GameBuffComponent))]
    [FriendOfAttribute(typeof(GameBuff))]
    public static partial class GameBuffComponentSystem
    {
        [EntitySystem]
        private static void Awake(this GameBuffComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this GameBuffComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this GameBuffComponent self)
        {
            foreach (Entity child in self.Children.Values)
            {
                self.GameBuffs.Add(child as GameBuff);
            }
        }

        [EntitySystem]
        private static void Update(this GameBuffComponent self)
        {
        }

        public static void AddBuff(this GameBuffComponent self, int configId, Entity sourceUnit)
        {
            if (configId < 1)
            {
                return;
            }

            GameBuff buff = self.Get(configId);
            if (buff == null)
            {
                buff = self.AddChild<GameBuff, int>(configId);
                self.AddBuffComponent(buff);
                self.GameBuffs.Add(buff);
            }
            else
            {
                buff.ResetRemainderTime();
            }
        }

        private static void AddBuffComponent(this GameBuffComponent self, GameBuff buff)
        {
            buff.AddComponent<GameBuffContinueComponent>();

            BuffType type = buff.Config.Type;
            switch (type)
            {
                case BuffType.BuffType_ModifyProperty:
                    buff.AddComponent<GameBuffModifyPropertyComponent>();
                    break;
                case BuffType.BuffType_Control:
                    buff.AddComponent<GameBuffControlComponent>();
                    break;
                case BuffType.BuffType_ContinueDamage:
                    buff.AddComponent<GameBuffCounter>();
                    break;
                case BuffType.BuffType_Action:
                    buff.AddComponent<GameBuffActionComponent>();
                    break;
                default:
                    Log.Error("无效的buff类型，请检查配置");
                    break;
            }
        }

        private static GameBuff Get(this GameBuffComponent self, int configId)
        {
            GameBuff buff = null;

            foreach (var entityRef in self.GameBuffs)
            {
                GameBuff temp = entityRef;
                if (temp == null || temp.IsDisposed)
                {
                    continue;
                }

                if (temp.ConfigId == configId)
                {
                    buff = temp;
                    break;
                }
            }

            return buff;
        }
    }
}