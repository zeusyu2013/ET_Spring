namespace ET.Server
{
    [EntitySystemOf(typeof(GameMasterComponent))]
    public static partial class GameMasterComponentSystem
    {
        private static void Awake(this GameMasterComponent self)
        {
        }

        public static void Execute(this GameMasterComponent self, Unit unit, string command)
        {
            var commands = command.Split(" ");
            if (commands.Length < 2)
            {
                return;
            }

            switch (commands[0])
            {
                case "AddExp":
                {
                    long exp = long.Parse(commands[1]);
                    unit.GetComponent<LevelComponent>().AddExp(exp);
                    break;
                }

                case "AddItem":
                {
                    int itemConfig = int.Parse(commands[1]);
                    long itemAmount = long.Parse(commands[2]);
                    unit.GetComponent<BagComponent>().AddItem(itemConfig, itemAmount);
                    break;
                }

                case "AddCurrency":
                {
                    int currencyType = int.Parse(commands[1]);
                    long currencyValue = long.Parse(commands[2]);
                    unit.GetComponent<CurrencyComponent>().Inc((CurrencyType)currencyType, currencyValue, "GM产出");
                    break;
                }

                case "AddTask":
                {
                    int taskConfig = int.Parse(commands[1]);
                    unit.GetComponent<GameTaskComponent>().AcceptTask(taskConfig);
                    break;
                }

                case "AddSoul":
                {
                    int soulConfig = int.Parse(commands[1]);
                    unit.GetComponent<SoulComponent>().Add(soulConfig);
                    break;
                }
            }
        }
    }
}