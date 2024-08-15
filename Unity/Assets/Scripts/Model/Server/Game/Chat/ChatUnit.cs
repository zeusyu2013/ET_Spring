namespace ET.Server
{
    /// <summary>
    /// 聊天服务器上存玩家的映射
    /// </summary>
    [ChildOf(typeof(ChatUnitsComponent))]
    public class ChatUnit : Entity, IAwake, IDestroy
    {
        // 
        public long GateSessionActorId;
        
        // unit名字
        public string Name;
        
    }
}

