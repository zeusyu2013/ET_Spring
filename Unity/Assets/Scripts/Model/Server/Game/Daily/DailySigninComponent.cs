namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class DailySigninComponent : Entity, IAwake, ISerializeToEntity
    {
        public int SigninDay;
    }
}