namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_SigninHandler : MessageLocationHandler<Unit, C2M_Signin, M2C_Signin>
    {
        protected override async ETTask Run(Unit unit, C2M_Signin request, M2C_Signin response)
        {
            int errorCode = unit.GetComponent<DailySigninComponent>().Signin();

            response.Error = errorCode;

            await ETTask.CompletedTask;
        }
    }
}