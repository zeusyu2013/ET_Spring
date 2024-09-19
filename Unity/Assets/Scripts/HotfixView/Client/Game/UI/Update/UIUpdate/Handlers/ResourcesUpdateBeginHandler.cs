namespace ET.Client
{
    [Event(SceneType.Main)]
    public class ResourcesUpdateBeginHandler : AEvent<Scene, ResourcesUpdateBegin>
    {
        protected override async ETTask Run(Scene scene, ResourcesUpdateBegin args)
        {
            int totalDownloadCount = args.TotalDownloadCount;
            long totalDownloadBytes = args.TotalDownloadBytes;
            
            // todo:弹出messagebox，提示玩家下载资源数量与大小
            
            await ETTask.CompletedTask;
        }
    }
}