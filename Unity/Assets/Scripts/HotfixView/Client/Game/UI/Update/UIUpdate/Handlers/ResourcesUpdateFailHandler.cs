namespace ET.Client
{
    [Event(SceneType.Main)]
    public class ResourcesUpdateFailHandler : AEvent<Scene, ResourcesUpdateFail>
    {
        protected override async ETTask Run(Scene scene, ResourcesUpdateFail args)
        {
            string fileName = args.FileName;
            string error = args.Error;
            
            // todo:提示玩家{filename}文件下载错误{error}，并重试
            
            await ETTask.CompletedTask;
        }
    }
}