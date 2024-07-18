using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(TalentComponent))]
    [FriendOfAttribute(typeof(ET.Server.TalentComponent))]
    [FriendOfAttribute(typeof(ET.Server.Talent))]
    public static partial class TalentComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.TalentComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.TalentComponent self)
        {
            self.Talents.Clear();
            self.TalentPoint = 0;
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.TalentComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                self.Talents.Add(entity as Talent);
            }
        }

        public static List<TalentInfo> GetTalents(this TalentComponent self)
        {
            List<TalentInfo> infos = new();
            foreach (EntityRef<Talent> entityRef in self.Talents)
            {
                Talent talent = entityRef;
                if (talent == null)
                {
                    continue;
                }

                infos.Add(talent.ToMessage());
            }

            return infos;
        }

        public static void AddTalentPoint(this TalentComponent self, int point)
        {
            self.TalentPoint += point;
        }

        public static void Reset(this TalentComponent self)
        {
            if (self.Talents.Count < 1)
            {
                return;
            }

            // TODO:检查重置天赋消耗
            int currencyType = GlobalDataConfigCategory.Instance.ResetTalentCurrency;
            long currencyValue = GlobalDataConfigCategory.Instance.ResetTalentCurrencyValue;
            Unit unit = self.GetParent<Unit>();
            bool ret = unit.GetComponent<CurrencyComponent>().Dec((CurrencyType)currencyType, currencyValue, "重置天赋");
            if (!ret)
            {
                return;
            }

            int point = 0;
            foreach (EntityRef<Talent> entityRef in self.Talents)
            {
                Talent talent = entityRef;
                if (talent == null)
                {
                    continue;
                }

                point = talent.Config.Consume * talent.Level;
            }

            if (point < 1)
            {
                return;
            }

            self.TalentPoint += point;

            self.Talents.Clear();
            foreach (Entity entity in self.Children.Values)
            {
                entity?.Dispose();
            }

            self.Children.Clear();
        }

        public static void AddTalent(this TalentComponent self, int configId)
        {
            TalentConfig config = TalentConfigCategory.Instance.Get(configId);
            if (self.TalentPoint < config.Consume)
            {
                return;
            }

            Talent talent = self.Talents.Find(x => ((Talent)x).ConfigId == configId);
            if (talent == null)
            {
                // 学习天赋
                talent = self.AddChild<Talent, int>(configId);
                talent.Level = 1;
                self.Talents.Add(talent);
            }
            else
            {
                // 升级天赋
                talent.Level += 1;
            }

            self.TalentPoint -= config.Consume;
        }
    }
}