namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.Client.ClientCast))]
    public static class CastFactory
    {
        public static ClientCast Create(Unit caster, long id, int configId)
        {
            ClientCast clientCast = caster.GetComponent<ClientCastComponent>().AddComponentWithId<ClientCast, int>(id, configId);
            clientCast.CasterId = caster.Id;
            
            return clientCast;
        }
    }
}