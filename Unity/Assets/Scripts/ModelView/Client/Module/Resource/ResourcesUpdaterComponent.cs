using YooAsset;

namespace ET.Client
{
    [ComponentOf]
    public class ResourcesUpdaterComponent : Entity, IAwake, IDestroy
    {
        public ResourcePackage Package;

        public ResourceDownloaderOperation DownloaderOperation;
    }
}