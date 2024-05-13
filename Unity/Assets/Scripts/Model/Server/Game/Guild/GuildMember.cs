namespace ET.Server
{
    [ChildOf(typeof(Guild))]
    public class GuildMember : Entity, IAwake, ISerializeToEntity
    {
        public long UnitId;

        public int GuildMemberType;

        public int OnlineStatus;

        public long OfflineTime;
    }
}