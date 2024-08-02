namespace ET.Server
{
    [Event(SceneType.Map)]
    public class NumericChange_UnitHandler : AEvent<Scene, NumbericChange>
    {
        protected override async ETTask Run(Scene scene, NumbericChange args)
        {
            M2C_NumericChange m2CNumericChange = M2C_NumericChange.Create();
            m2CNumericChange.UnitId = args.Unit.Id;
            m2CNumericChange.KV.Add(args.NumericType, args.New);

            BattleMessageHelper.SendClient(args.Unit, m2CNumericChange, MessageNotifyType.MessageNotifyType_Broadcast);

            await ETTask.CompletedTask;
        }
    }
}