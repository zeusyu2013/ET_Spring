namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.Server.Cast))]
    public static class CastHelper
    {
        public static Cast Create(this Unit caster, int castConfigId)
        {
            CastComponent castComponent = caster.GetComponent<CastComponent>();
            if (castComponent == null)
            {
                return null;
            }

            Cast cast = castComponent.Create(castConfigId);
            cast.Caster = caster;

            return cast;
        }

        /// <summary>
        /// 创建并释放技能
        /// </summary>
        /// <param name="caster"></param>
        /// <param name="castConfigId"></param>
        /// <param name="targetId">单体目标客户端传入对象</param>
        /// <returns></returns>
        public static int CreateAndCast(this Unit caster, int castConfigId, long targetId = 0)
        {
            return CreateCast(caster, castConfigId, targetId).Cast();
        }

        private static Cast CreateCast(this Unit caster, int castConfigId, long targetId = 0)
        {
            CastComponent castComponent = caster.GetComponent<CastComponent>();
            if (castComponent == null)
            {
                return null;
            }

            Cast cast = castComponent.Create(castConfigId);
            cast.Caster = caster;
            if (targetId > 0)
            {
                cast.Targets.Add(targetId);
            }

            caster.GetComponent<SkillStatusComponent>().StartCast(cast);

            return cast;
        }
    }
}