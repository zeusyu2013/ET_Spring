using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(DropComponent))]
    public static partial class DropComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.DropComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.DropComponent self)
        {
        }

        public struct DropRange
        {
            public int Min;
            public int Max;
        }

        public static void Drop(this DropComponent self, int dropConfig, ref List<DropItem> dropItems)
        {
            DropConfig config = DropConfigCategory.Instance.Get(dropConfig);
            if (config == null)
            {
                return;
            }

            if (config.DropCount >= config.DropList.Count)
            {
                Log.Error($"掉落个数大于等于掉落列表数量，请检查配置 掉落编号：{dropConfig}");
                return;
            }

            int rate = 0;
            foreach (DropItem dropItem in config.DropList)
            {
                rate += dropItem.ItemRate;
            }

            if (rate >= 10000)
            {
                Log.Error($"掉落列表总概率大于10000，请检查配置 掉落编号: {dropConfig}");
                return;
            }

            // 非必定掉落
            int certainty = RandomGenerator.RandomNumber(0, 10000);
            if (certainty > config.DropCertainty)
            {
                Log.Info($"触发非必定掉落，掉落编号：[{dropConfig}] 随机确定性：[{certainty}] 掉落确定性：[{config.DropCertainty}]");
                return;
            }
            
            // 必定掉落
            int index = 0;
            Dictionary<DropRange, DropItem> ranges = new();
            foreach (DropItem dropItem in config.DropList)
            {
                ranges.Add(new DropRange() { Min = index, Max = index + dropItem.ItemRate }, dropItem);

                index += dropItem.ItemRate;
            }

            int dropCount = 0;
            while (dropCount >= config.DropCount)
            {
                int random = RandomGenerator.RandomNumber(0, 10000);
                foreach ((DropRange range, DropItem item) in ranges)
                {
                    if (range.Min > random || random >= range.Max)
                    {
                        continue;
                    }

                    dropItems.Add(item);
                    dropCount += 1;
                    break;
                }
            }
        }
    }
}