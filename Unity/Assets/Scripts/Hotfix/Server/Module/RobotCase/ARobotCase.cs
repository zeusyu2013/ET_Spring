namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.RobotCase))]    // 这里为什么能定义class呢？因为这里只有逻辑，热重载后新的handler替换旧的，仍然没有问题
    public abstract class ARobotCase : AInvokeHandler<RobotInvokeArgs, ETTask>
    {
        protected abstract ETTask Run(RobotCase robotCase);

        public override async ETTask Handle(RobotInvokeArgs args)
        {
            using RobotCase robotCase = await args.Fiber.Root.GetComponent<RobotCaseComponent>().New();
            robotCase.CommandLine = args.Content;
            try
            {
                await this.Run(robotCase);
            }
            catch (System.Exception e)
            {
                Log.Error($"{robotCase.Zone()} {e}");
                Log.Console($"RobotCase Error {this.GetType().FullName}:\n\t{e}");
            }
        }
    }
}