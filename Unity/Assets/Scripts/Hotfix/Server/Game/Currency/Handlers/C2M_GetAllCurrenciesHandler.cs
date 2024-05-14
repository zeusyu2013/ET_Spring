using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(CurrencyComponent))]
    public class C2M_GetAllCurrenciesHandler : MessageLocationHandler<Unit, C2M_GetAllCurrencies, M2C_GetAllCurrencies>
    {
        protected override async ETTask Run(Unit unit, C2M_GetAllCurrencies request, M2C_GetAllCurrencies response)
        {
            Dictionary<int, long> currencies = unit.GetComponent<CurrencyComponent>().Currencies;
            if (currencies.Count < 1)
            {
                response.Error = ErrorCode.ERR_NotFoundCurrencies;
                response.Message = "没有任何货币";
                return;
            }

            foreach ((int type, long value) in currencies)
            {
                CurrencyInfo info = CurrencyInfo.Create();
                info.Type = type;
                info.Value = value;
                response.CurrencyInfos.Add(info);
            }

            await ETTask.CompletedTask;
        }
    }
}