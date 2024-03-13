namespace ET.Client
{
    [Event(SceneType.Demo)]
    [FriendOf(typeof(InputComponent))]
    public class JoystickMove_RefreshMoveDirection : AEvent<Scene, JoystickMove>
    {
        protected override async ETTask Run(Scene scene, JoystickMove args)
        {
            var inputComponent = scene.GetComponent<InputComponent>();

            if (args.IsMove)
            {
                inputComponent.JoystickMoveDirection.x = args.DeltaX;
                inputComponent.JoystickMoveDirection.z = args.DeltaY * -1;
            }
            else
            {
                inputComponent.JoystickMoveDirection.x = 0;
                inputComponent.JoystickMoveDirection.z = 0;
            }

            await ETTask.CompletedTask;
        }
    }
}

