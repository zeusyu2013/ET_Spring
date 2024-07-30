namespace ET.Client
{
    public static class ClientCastHelper
    {
        public static async ETTask<int> CastSkill(Scene scene, int castConfigId)
        {
            C2M_Cast c2MCast = C2M_Cast.Create();
            c2MCast.CastConfigId = castConfigId;

            M2C_Cast m2CCast = (M2C_Cast)await scene.Root().GetComponent<ClientSenderComponent>().Call(c2MCast);

            return m2CCast.Error;
        }
    }
}