using System.Collections.Generic;

namespace ET.Server
{
    [EntitySystemOf(typeof(SelectTargetComponent))]
    public static partial class SelectTargetComponentSystem
    {
        [EntitySystem]
        private static void Awake(this SelectTargetComponent self)
        {
        }

        public static int Check(this SelectTargetComponent self, int configId, ref List<long> targets)
        {
            CastConfig config = CastConfigCategory.Instance.Get(configId);

            ASelectTargetHandler handler = SelectTargetDispatcherComponent.Instance.Get(config.SelectTargetType.ToString());
            if (handler == null)
            {
                return ErrorCode.ERR_NotFoundSkillSelectHandler;
            }

            return handler.Check(self, config, ref targets);
        }
    }
}