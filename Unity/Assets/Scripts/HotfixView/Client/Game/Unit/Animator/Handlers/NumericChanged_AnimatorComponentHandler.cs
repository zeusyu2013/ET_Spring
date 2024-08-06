namespace ET.Client
{
    [Event(SceneType.Current)]
    [FriendOfAttribute(typeof(ET.Client.AnimatorComponent))]
    public class NumericChanged_AnimatorComponentHandler : AEvent<Scene, NumbericChange>
    {
        protected override async ETTask Run(Scene scene, NumbericChange args)
        {
            if (args.NumericType != (int)GamePropertyType.GP_Speed)
            {
                return;
            }

            Unit unit = args.Unit;
            if (unit == null || unit.IsDisposed)
            {
                return;
            }

            AnimatorComponent animatorComponent = unit.GetComponent<AnimatorComponent>();
            if (animatorComponent == null)
            {
                return;
            }

            if (animatorComponent.isStop)
            {
                return;
            }

            // todo 根据移动速度改变动画速度
            //animatorComponent.SetAnimatorSpeed();

            await ETTask.CompletedTask;
        }
    }
}