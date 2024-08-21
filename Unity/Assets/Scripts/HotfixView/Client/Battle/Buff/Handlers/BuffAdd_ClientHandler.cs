using UnityEngine;

namespace ET.Client
{
    [Event(SceneType.MainClient)]
    [FriendOfAttribute(typeof(ET.Client.ClientBuff))]
    public class BuffAdd_ClientHandler : AEvent<Scene, BuffAdd>
    {
        protected override async ETTask Run(Scene scene, BuffAdd args)
        {
            ClientBuff buff = args.Unit.GetComponent<ClientBuffComponent>().Get(args.BuffId);
            if (buff == null)
            {
                return;
            }

            BuffClientConfig config = BuffClientConfigCategory.Instance.Get(buff.ConfigId);
            string fxName = config.AddFx;
            if (string.IsNullOrEmpty(fxName))
            {
                return;
            }

            GameObjectComponent gameObjectComponent = args.Unit.GetComponent<GameObjectComponent>();
            Transform bindPoint = gameObjectComponent.GetBindPoint(config.AddFxBindPoint);
            if (bindPoint == null)
            {
                bindPoint = gameObjectComponent.Transform;
            }

            FxComponent fxComponent = scene.CurrentScene().GetComponent<FxComponent>();

            // 播放特效
            Transform fx = await fxComponent.Spwan(fxName, bindPoint);
            fx.name = fxName;

            fxComponent.Add(fx, TimeInfo.Instance.ClientNow() + config.AddFxTime);
        }
    }
}