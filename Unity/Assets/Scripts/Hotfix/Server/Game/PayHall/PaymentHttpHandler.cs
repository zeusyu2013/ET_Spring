using System.Net;

namespace ET.Server
{
    [HttpHandler(SceneType.PayHall, "/wanxin/charge")]
    public class PaymentHttpHandler : IHttpHandler
    {
        public async ETTask Handle(Scene scene, HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            if (!request.HttpMethod.Equals("GET"))
            {
                return;
            }
            
            WanxinPayResponse response = await scene.GetComponent<PaymentComponent>().CheckWanxinOrder(request.QueryString);

            HttpHelper.Response(context, response);
        }
    }
}