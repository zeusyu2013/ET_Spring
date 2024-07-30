namespace ET
{
	public static partial class UnitComponentSystem
	{
		public static void Add(this UnitComponent self, Unit unit)
		{
		}

		public static Unit Get(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			return unit;
		}

		public static void Remove(this UnitComponent self, long id)
		{
			Unit unit = self.GetChild<Unit>(id);
			unit?.Dispose();
		}

		public static Unit GetUnit(this Scene scene, long id)
		{
			UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
			if (unitComponent == null)
			{
				Log.Error($"场景 {scene.Name} 没有UnitComponent组件");
				return null;
			}
			
			return unitComponent.Get(id);
		}
	}
}