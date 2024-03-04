using System.Collections.Generic;

/*
 * 以组的形式打开界面，（简单理解为：多个单独的界面一起组成一个完整的界面）
 * 
 */

namespace ET.Client
{
    [ComponentOf(typeof(UIComponent))]
    public class UIGroupComponent : Entity, IAwake, IDestroy
    { 
        // 界面formID
        public UIDefine.GroupId GroupId { get; set; }
        // 回溯队列
        public Stack<int> IdStack = new();
        
    }
}



