namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.SoulCast))]
    public static class SoulCastHelper
    {
        public static int Create(this Soul soul, int configId)
        {
            SoulCastComponent component = soul.GetComponent<SoulCastComponent>();
            if (component == null)
            {
                return ErrorCode.ERR_SoulCastComponentIsNull;
            }

            SoulCast cast = component.Create(configId);
            cast.Caster = soul;

            cast.Cast();

            return ErrorCode.ERR_Success;
        }
    }
}