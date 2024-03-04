﻿using System.Collections.Generic;

namespace ET;

public partial class UIGroupSubConfigCategory
{
    private Dictionary<int, List<UIGroupSubConfig>> subGroupDic = new();
    
    /// <summary>
    /// 整理配置，方便以后逻辑调用
    /// </summary>
    public void InitSubConfig()
    {
        subGroupDic.Clear();
        foreach (var kv in dict)
        {
            int groupId = kv.Value.FormId;
            subGroupDic.TryGetValue(groupId, out var list);
            if (list == null)
            {
                list = new List<UIGroupSubConfig>();
            }
            list.Add(kv.Value);
        }
    }

    /// <summary>
    /// 获取sub组界面数据
    /// </summary>
    /// <param name="groupId">组Id</param>
    /// <returns></returns>
    public List<UIGroupSubConfig> GetGroupSubData(int groupId)
    {
        subGroupDic.TryGetValue(groupId, out var list);
        return list;
    }
}