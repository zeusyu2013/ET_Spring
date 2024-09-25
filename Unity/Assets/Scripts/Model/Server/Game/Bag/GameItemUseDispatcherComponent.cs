using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Code]
    public class GameItemUseDispatcherComponent : Singleton<GameItemUseDispatcherComponent>, ISingletonAwake
    {
        public Dictionary<GameItemUseType, IGameItemUse> GameItemUses = new();

        public void Awake()
        {
            var types = CodeTypes.Instance.GetTypes(typeof(GameItemUseAttribute));
            foreach (Type type in types)
            {
                var attrs = type.GetCustomAttributes(typeof(GameItemUseAttribute), false);
                if (attrs.Length == 0)
                {
                    continue;
                }

                GameItemUseAttribute attribute = attrs[0] as GameItemUseAttribute;

                object o = Activator.CreateInstance(type);

                if (o is not IGameItemUse iItemUse)
                {
                    return;
                }

                GameItemUses[attribute.Type] = iItemUse;
            }
        }

        public IGameItemUse Get(GameItemUseType useType)
        {
            return this.GameItemUses.GetValueOrDefault(useType);
        }
    }
}