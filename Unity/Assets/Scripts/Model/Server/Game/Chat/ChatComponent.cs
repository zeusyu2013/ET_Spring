namespace ET.Server
{
    /// <summary>
    /// 聊天功能
    /// 根据聊天私密程度，可分为私聊、小队、公会、本地、世界、跨服
    /// 讲这些情况划分为不同的聊天频道Channel
    /// 私聊 ： 两个人之间的消息转发
    /// 小队 ： 队伍之间的消息转发
    /// 公会 ： 公会成员之间的消息转发
    /// 本地 ： 本地玩家的的消息准发（本地的密度需要确定，单个Map服，还是根据位置半径再细分）
    /// 世界 ： 服务器所有玩家之间的消息转发
    /// 跨服 ： 不同服务器之间的消息转发
    /// </summary>
    [ComponentOf]
    public class ChatComponent : Entity, IAwake, IDestroy
    {
    }
}