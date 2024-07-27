namespace ET.Client
{
    [MessageHandler(SceneType.MainClient)]
    [FriendOfAttribute(typeof(ET.Client.ClientCast))]
    public class M2C_CastHitHandler : MessageHandler<Scene, M2C_CastHit>
    {
        protected override async ETTask Run(Scene scene, M2C_CastHit message)
        {
            Log.Console($"玩家{message.CasterId} 的技能{message.CastId} 命中 {message.Targets}");

            Unit caster = scene.GetComponent<UnitComponent>().Get(message.CasterId);
            if (caster == null)
            {
                return;
            }

            ClientCast clientCast = caster.GetComponent<ClientCastComponent>().Get(message.CastId);
            if (clientCast == null)
            {
                return;
            }

            clientCast.Targets.Clear();

            foreach (long tid in message.Targets)
            {
                Unit target = scene.GetComponent<UnitComponent>().Get(tid);
                if (target == null || target.IsDisposed)
                {
                    continue;
                }
                
                clientCast.Targets.Add(tid);
            }
            
            EventSystem.Instance.Publish(scene, new CastHit(){});

            await ETTask.CompletedTask;
        }
    }
}