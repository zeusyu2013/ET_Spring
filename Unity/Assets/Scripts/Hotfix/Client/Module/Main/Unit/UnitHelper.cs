namespace ET.Client
{
    public static partial class UnitHelper
    {
        public static Unit GetMyUnitFromClientScene(Scene root)
        {
            GameUnitComponent gameUnitComponent = root.GetComponent<GameUnitComponent>();
            Scene currentScene = root.GetComponent<CurrentScenesComponent>().Scene;
            return currentScene.GetComponent<UnitComponent>().Get(gameUnitComponent.UnitId);
        }

        public static Unit GetMyUnitFromCurrentScene(Scene currentScene)
        {
            GameUnitComponent gameUnitComponent = currentScene.Root().GetComponent<GameUnitComponent>();
            return currentScene.GetComponent<UnitComponent>().Get(gameUnitComponent.UnitId);
        }

        public static bool IsMyUnit(this Unit unit)
        {
            if (unit == null || unit.IsDisposed)
            {
                return false;
            }
            
            GameUnitComponent gameUnitComponent = unit.Root().GetComponent<GameUnitComponent>();
            
            return gameUnitComponent.UnitId == unit.Id;
        }
    }
}