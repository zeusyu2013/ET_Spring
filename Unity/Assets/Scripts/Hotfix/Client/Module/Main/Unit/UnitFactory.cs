﻿namespace ET.Client
{
    public static partial class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
            currentScene.Root().GetComponent<PlayerComponent>().UnitId = unitInfo.UnitId;

            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
            unitComponent.Add(unit);

            unit.Position = unitInfo.Position;
            unit.Forward = unitInfo.Forward;

            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();

            foreach (var kv in unitInfo.KV)
            {
                numericComponent.Set(kv.Key, kv.Value);
            }

            unit.AddComponent<MoveComponent>();
            if (unitInfo.MoveInfo != null)
            {
                if (unitInfo.MoveInfo.Points.Count > 0)
                {
                    unitInfo.MoveInfo.Points[0] = unit.Position;
                    unit.MoveToAsync(unitInfo.MoveInfo.Points).Coroutine();
                }
            }

            unit.AddComponent<ObjectWait>();

            unit.AddComponent<XunLuoPathComponent>();
            unit.AddComponent<ClientCastComponent>();
            unit.AddComponent<ClientBuffComponent>();

            EventSystem.Instance.Publish(unit.Scene(), new AfterUnitCreate() { Unit = unit });
            return unit;
        }

        public static Unit CreateFxUnit(Scene currentScene, int fxConfigId)
        {
            UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit fx = unitComponent.AddChild<Unit, int>(fxConfigId);
            unitComponent.Add(fx);

            fx.AddComponent<ObjectWait>();

            return fx;
        }
    }
}