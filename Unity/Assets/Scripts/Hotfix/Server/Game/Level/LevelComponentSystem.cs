﻿namespace ET.Server
{
    [EntitySystemOf(typeof(LevelComponent))]
    [FriendOf(typeof(LevelComponent))]
    public static partial class LevelComponentSystem
    {
        private static void Awake(this LevelComponent self, int level)
        {
            self.Level = level;
        }

        private static void Destroy(this LevelComponent self)
        {
        }

        public static void AddExp(this LevelComponent self, long exp)
        {
            long current = self.Exp + exp;
            long max = ExpConfigCategory.Instance.Get(self.Level).Exp;
            if (max < 1)
            {
                self.Exp += exp;
                return;
            }

            while (current >= max)
            {
                current -= max;

                self.Level += 1;

                max = ExpConfigCategory.Instance.Get(self.Level).Exp;
                if (max < 1)
                {
                    break;
                }
            }

            self.Exp = current;

            self.Boardcast();
        }

        public static void Boardcast(this LevelComponent self)
        {
            Unit unit = self.GetParent<Unit>();
            
            unit.SetInt(GamePropertyType.GamePropertyType_Level, self.Level);
            unit.SetLong(GamePropertyType.GamePropertyType_Exp, self.Exp);
        }
    }
}