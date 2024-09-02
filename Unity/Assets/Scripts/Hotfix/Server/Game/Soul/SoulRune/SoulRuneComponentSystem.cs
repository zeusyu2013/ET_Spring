using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof(SoulRuneComponent))]
    public static partial class SoulRuneComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.SoulRuneComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.SoulRuneComponent self)
        {
        }

        [EntitySystem]
        private static void Deserialize(this ET.Server.SoulRuneComponent self)
        {
            foreach (SoulRune soulRune in self.Children.Values.Cast<SoulRune>())
            {
                self.AddChild(soulRune);
            }
        }
    }
}