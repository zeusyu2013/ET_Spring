using System;

namespace ET
{
    public class AIHandlerAttribute : BaseAttribute
    {
        public AIType AIType;

        public AIHandlerAttribute(AIType aiType)
        {
            this.AIType = aiType;
        }
    }

    public abstract class AAIHandler : HandlerObject
    {
        // 检查是否满足条件
        public abstract int Check(AIComponent aiComponent, AIConfig aiConfig);

        // 协程编写必须可以取消
        public abstract ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken);
    }
}