namespace ET.Server
{
    /// <summary>
    /// 聊天服务器上存玩家的映射
    /// </summary>
    [ComponentOf(typeof(ChatUnitsComponent))]
    public class ChatUnit : Entity, IAwake, IDestroy
    {
        // 
        public long GateSessionActorId;

        public string Name;
    }
}

