using System.Collections.Generic;

namespace ET
{
    public partial class UIGroupConfig
    {
        private List<UIGroupSubConfig> groupSubConfigs;

        public List<UIGroupSubConfig> GroupSubConfigs
        {
            get
            {
                if (groupSubConfigs != null)
                {
                    return groupSubConfigs;
                }

                if (this.SubIds == null)
                {
                    return null;
                }

                groupSubConfigs = new List<UIGroupSubConfig>();
                int count = this.SubIds.Count;
                for (int i = 0; i < count; i++)
                {
                    var subData = UIGroupSubConfigCategory.Instance.Get(this.SubIds[i]);
                    if (subData == null)
                    {
                        continue;
                    }
                    groupSubConfigs.Add(subData);
                }

                return groupSubConfigs;
            }
            
        }

    }
}

