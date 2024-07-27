namespace ET.Client
{
    [Event(SceneType.Current)]
    public class CastStart_SoundHandler : AEvent<Scene, CastStart>
    {
        protected override async ETTask Run(Scene scene, CastStart args)
        {
            await ETTask.CompletedTask;
        }
    }
}