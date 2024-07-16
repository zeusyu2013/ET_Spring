namespace ET.Server
{
    [Event(SceneType.Map)]
    public class PayAmountChanged_VipComponentHandler : AEvent<Scene, PayAmountChanged>
    {
        protected override async ETTask Run(Scene scene, PayAmountChanged args)
        {
            Unit unit = args.Unit;
            if (unit == null)
            {
                return;
            }

            unit.GetComponent<VipComponent>().AddVipExp(args.NewAmount - args.OldAmount);

            await ETTask.CompletedTask;
        }
    }
}