namespace ET.Client
{
    [Event(SceneType.MainClient)]
    [FriendOf(typeof(InputComponent))]
    public class JoystickMove_RefreshMoveDirection : AEvent<Scene, JoystickMove>
    {
        protected override async ETTask Run(Scene scene, JoystickMove args)
        {
            var inputComponent = scene.GetComponent<InputComponent>();
            
            inputComponent.JoystickMoveDirection.x = args.DeltaX;
            inputComponent.JoystickMoveDirection.z = args.DeltaY * -1;
            
            await ETTask.CompletedTask;
        }
    }
}

