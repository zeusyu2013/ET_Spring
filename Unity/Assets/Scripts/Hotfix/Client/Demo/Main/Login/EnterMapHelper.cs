using System;


namespace ET.Client
{
    public static partial class EnterMapHelper
    {
        public static async ETTask EnterMapAsync(Scene root, long unitId)
        {
            try
            {
                C2G_EnterMap enterMap = C2G_EnterMap.Create();
                enterMap.UnitId = unitId;
                G2C_EnterMap g2CEnterMap = await root.GetComponent<ClientSenderComponent>().Call(enterMap) as G2C_EnterMap;
                
                // 等待场景切换完成
                await root.GetComponent<ObjectWait>().Wait<Wait_SceneChangeFinish>();
                
                EventSystem.Instance.Publish(root, new EnterMapFinish());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }	
        }
    }
}