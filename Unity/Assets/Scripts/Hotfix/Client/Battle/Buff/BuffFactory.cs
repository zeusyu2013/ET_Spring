namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.ClientBuff))]
    public static class BuffFactory
    {
        public static ClientBuff Create(Unit owner, BuffInfo info)
        {
            ClientBuff clientBuff = owner.GetComponent<ClientBuffComponent>().AddChildWithId<ClientBuff, int>(info.Id, info.ConfigId);
            clientBuff.Owner = owner;
            clientBuff.CreateTime = info.CreateTime;
            clientBuff.ExpiredTime = info.ExpiredTime;
            return clientBuff;
        }
    }
}