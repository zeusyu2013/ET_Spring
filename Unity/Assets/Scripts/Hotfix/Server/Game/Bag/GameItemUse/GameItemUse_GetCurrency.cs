﻿namespace ET.Server
{
    [GameItemUse(GameItemUseType.GameItemUseType_Currency)]
    [FriendOfAttribute(typeof(ET.GameItem))]
    public class GameItemUse_GetCurrency : IGameItemUse
    {
        public int Run(GameItem item, long useAmount)
        {
            ItemUseConfig config = ItemUseConfigCategory.Instance.Get(item.ConfigId);
            
            BagComponent bagComponent = item.GetParent<BagComponent>();

            Unit unit = bagComponent.GetParent<Unit>();

            GameItemUseCurrency conf = config.GameItemUseParam as GameItemUseCurrency;

            CurrencyType type = conf.CurrencyType;
            long value = conf.CurrencyValue * useAmount;

            int ret = unit.GetComponent<CurrencyComponent>().Inc(type, value, $"使用道具{config.Id} {useAmount}个");

            return ret;
        }
    }
}