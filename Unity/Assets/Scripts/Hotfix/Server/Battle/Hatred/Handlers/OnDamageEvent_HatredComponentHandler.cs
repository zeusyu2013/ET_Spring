namespace ET.Server
{
    [Event(SceneType.Map)]
    public class OnDamageEvent_HatredComponentHandler : AEvent<Scene, OnDamageEvent>
    {
        protected override async ETTask Run(Scene scene, OnDamageEvent args)
        {
            Unit target = args.Target;
            if (target.IsNull())
            {
                return;
            }

            HatredComponent hatredComponent = target.GetComponent<HatredComponent>();
            if (hatredComponent == null)
            {
                return;
            }

            // todo 这里需要根据caster技能和伤害计算仇恨值
            hatredComponent.IncHatred(args.Caster.Id, args.DamageValue);

            await ETTask.CompletedTask;
        }
    }
}