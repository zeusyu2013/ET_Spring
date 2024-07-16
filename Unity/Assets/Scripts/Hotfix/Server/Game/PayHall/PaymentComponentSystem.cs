using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ET.Server
{
    [FriendOf(typeof(WanxinOrder))]
    [EntitySystemOf(typeof(PaymentComponent))]
    public static partial class PaymentComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.PaymentComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.PaymentComponent self)
        {
        }

        public static async ETTask<WanxinPayResponse> CheckWanxinOrder(this PaymentComponent self, NameValueCollection request)
        {
            string app_order_id = request.Get("app_order_id");
            string app_role_id = request.Get("app_role_id");
            string is_sandbox = request.Get("is_sandbox");
            string channel = request.Get("channel");
            string xx_game_id = request.Get("xx_game_id");
            string product_id = request.Get("product_id");
            string order_id = request.Get("order_id");
            string server_id = request.Get("server_id");
            string total_fee = request.Get("total_fee");
            string sign = request.Get("sign");
            string user_id = request.Get("user_id");
            string time = request.Get("time");
            string tp = request.Get("tp");

            WanxinPayResponse response = WanxinPayResponse.Create();

            if (string.IsNullOrEmpty(app_order_id) || string.IsNullOrEmpty(app_role_id) ||
                string.IsNullOrEmpty(order_id) || string.IsNullOrEmpty(product_id) || string.IsNullOrEmpty(user_id))
            {
                response.Ret = 0;
                response.Message = "参数为空";
                return response;
            }

            if (xx_game_id != "2949")
            {
                response.Ret = 0;
                response.Message = "xx_game_id 不匹配";
                return response;
            }

            SortedDictionary<string, string> dict = new();
            dict.Add("app_order_id", app_order_id);
            dict.Add("app_role_id", app_role_id);
            dict.Add("xx_game_id", xx_game_id);
            dict.Add("order_id", order_id);
            dict.Add("xx_pay_sign", "7dc66df2b12f2d668aa279f1d76cbc44");
            dict.Add("product_id", product_id);
            dict.Add("server_id", server_id);
            dict.Add("total_fee", total_fee);
            dict.Add("user_id", user_id);
            dict.Add("time", time);
            dict.Add("channel", channel);

            if (!string.IsNullOrEmpty(is_sandbox) && !is_sandbox.Equals("0"))
            {
                dict.Add("is_sandbox", is_sandbox);
            }

            if (!string.IsNullOrEmpty(tp))
            {
                dict.Add("tp", tp);
            }

            string md5Sign = self.GenSign(dict);

            if (md5Sign != sign)
            {
                response.Ret = 0;
                response.Message = "签名 不匹配";
                return response;
            }

            long key = long.Parse(app_order_id);
            using (await self.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Pay, key))
            {
                DBComponent dbComponent = self.Root().GetComponent<DBManagerComponent>().GetZoneDB(self.Zone());
                if (dbComponent == null)
                {
                    response.Ret = 0;
                    response.Message = "数据库错误";
                    return response;
                }

                List<WanxinOrder> orders = await dbComponent.Query<WanxinOrder>(x => x.OrderId.Equals(app_order_id));
                if (orders.Count > 0)
                {
                    response.Ret = 0;
                    response.Message = "订单已存在";
                    return response;
                }

                WanxinOrder order = self.AddChild<WanxinOrder>();
                order.OrderId = app_order_id;
                order.UnitId = app_role_id;
                order.UserId = user_id;
                order.ServerId = server_id;
                order.ProductId = product_id;
                order.Time = DateTime.Now;

                await dbComponent.Save(order);
            }

            long unitId = long.Parse(app_role_id);

            Pay2M_Pay message = Pay2M_Pay.Create();
            message.UnitId = unitId;
            message.ProductId = product_id;

            List<StartSceneConfig> maps = StartSceneConfigCategory.Instance.Maps;
            foreach (StartSceneConfig config in maps)
            {
                self.Root().GetComponent<MessageSender>().Send(config.ActorId, message);
            }

            response.Ret = 1;
            response.Message = "success";

            return response;
        }

        private static string GenSign(this PaymentComponent self, SortedDictionary<string, string> dict)
        {
            StringBuilder sb = new();

            int i = 0;
            foreach (var kv in dict)
            {
                sb.Append($"{kv.Key}={kv.Value}");

                if (i != dict.Count - 1)
                {
                    sb.Append("&");
                }

                i += 1;
            }

            string sign = sb.ToString().ToLower();

            sign = MD5Helper.SigntureMD5(sign);

            return sign;
        }
    }
}