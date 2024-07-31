namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    public class M2C_CastFinishHandler : MessageHandler<Scene, M2C_CastFinish>
    {
        protected override async ETTask Run(Scene scene, M2C_CastFinish message)
        {
            Log.Console($"玩家{message.CasterId} 的技能{message.CastId} 结束");

            Unit caster = scene.CurrentScene().GetComponent<UnitComponent>().Get(message.CasterId);
            if (caster == null)
            {
                return;
            }

            ClientCast clientCast = caster.GetComponent<ClientCastComponent>().Get(message.CastId);
            if (clientCast == null)
            {
                return;
            }
            
            EventSystem.Instance.Publish(scene, new CastFinish()
            {
                CasterId = message.CasterId,
                CastId = message.CastId
            });

            caster.GetComponent<ClientCastComponent>().Remove(message.CastId);

            await ETTask.CompletedTask;
        }
    }
}