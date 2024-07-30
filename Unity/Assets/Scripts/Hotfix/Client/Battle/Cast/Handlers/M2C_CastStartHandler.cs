namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    [FriendOfAttribute(typeof(ET.Client.ClientCast))]
    public class M2C_CastStartHandler : MessageHandler<Scene, M2C_CastStart>
    {
        protected override async ETTask Run(Scene scene, M2C_CastStart message)
        {
            long casterId = message.CasterId;
            int castConfigId = message.CastConfigId;
            long castId = message.CastId;

            Log.Console($"玩家 {casterId} 开始释放 {castConfigId} 技能 {castId}");

            Unit caster = scene.GetComponent<UnitComponent>().Get(casterId);
            if (caster == null)
            {
                return;
            }

            ClientCast clientCast = CastFactory.Create(caster, castId, castConfigId);
            clientCast.Targets.AddRange(message.Targets);

            EventSystem.Instance.Publish(scene, new CastStart()
            {
                CasterId = casterId, 
                CastConfigId = castConfigId, 
                CastId = castId
            });

            caster.GetComponent<ClientCastComponent>().Add(clientCast);

            await ETTask.CompletedTask;
        }
    }
}