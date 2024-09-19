using YooAsset;

namespace ET.Client
{
    [EntitySystemOf(typeof(ResourcesUpdaterComponent))]
    [FriendOfAttribute(typeof(ET.Client.ResourcesUpdaterComponent))]
    public static partial class ResourcesUpdaterComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Client.ResourcesUpdaterComponent self)
        {
            self.Package = YooAssets.GetPackage("zz");
        }

        [EntitySystem]
        private static void Destroy(this ET.Client.ResourcesUpdaterComponent self)
        {
            self.DownloaderOperation.OnStartDownloadFileCallback = null;
            self.DownloaderOperation.OnDownloadProgressCallback = null;
            self.DownloaderOperation.OnDownloadOverCallback = null;
            self.DownloaderOperation.OnDownloadErrorCallback = null;
            self.DownloaderOperation = null;
        }

        public static async ETTask<string> UpdatePackageVersion(this ResourcesUpdaterComponent self)
        {
            UpdatePackageVersionOperation operation = self.Package.UpdatePackageVersionAsync();
            await operation.Task;

            bool success = operation.Status == EOperationStatus.Succeed;
            string packageVersion = "";
            if (success)
            {
                packageVersion = operation.PackageVersion;
                Log.Info($"更新package version成功：{packageVersion}");
            }
            else
            {
                Log.Error($"更新package version失败：{operation.Error}");
            }

            return packageVersion;
        }

        public static async ETTask<bool> UpdatePackageManifest(this ResourcesUpdaterComponent self, string packageVersion)
        {
            UpdatePackageManifestOperation operation = self.Package.UpdatePackageManifestAsync(packageVersion);
            await operation.Task;

            bool success = operation.Status == EOperationStatus.Succeed;
            if (success)
            {
                Log.Info($"更新package manifest成功：{packageVersion}");
            }
            else
            {
                Log.Error($"更新package manifest失败：{operation.Error}");
            }

            return success;
        }

        public static void CheckDownload(this ResourcesUpdaterComponent self, int downloadingCount = 10, int retryCount = 3)
        {
            self.DownloaderOperation = self.Package.CreateResourceDownloader(downloadingCount, retryCount);
            if (self.DownloaderOperation.TotalDownloadCount < 1)
            {
                Log.Warning("没有可下载资源");

                EventSystem.Instance.Publish(self.Scene(), new ResourcesUpdateNoResources());
                
                return;
            }

            int totalDownloadCount = self.DownloaderOperation.TotalDownloadCount;
            long totalDonwloadBytes = self.DownloaderOperation.TotalDownloadBytes;

            EventSystem.Instance.Publish(self.Scene(),
                new ResourcesUpdateBegin()
                {
                    TotalDownloadCount = totalDownloadCount,
                    TotalDownloadBytes = totalDonwloadBytes
                });
        }

        public static void Download(this ResourcesUpdaterComponent self)
        {
            self.DownloaderOperation.OnStartDownloadFileCallback = self.OnStartDownloadFileCallback;
            self.DownloaderOperation.OnDownloadProgressCallback = self.OnDownloadProgressCallback;
            self.DownloaderOperation.OnDownloadOverCallback = self.OnDownloadOverCallback;
            self.DownloaderOperation.OnDownloadErrorCallback = self.OnDownloadErrorCallback;

            self.DownloaderOperation.BeginDownload();
        }

        private static void OnStartDownloadFileCallback(this ResourcesUpdaterComponent self, string fileName, long sizeBytes)
        {
            EventSystem.Instance.Publish(self.Scene(), new ResourcesUpdateStart() { FileName = fileName, FileBytes = sizeBytes });
        }

        private static void OnDownloadProgressCallback(this ResourcesUpdaterComponent self, int totalDownloadCount, int currentDownloadCount,
        long totalDownloadBytes, long currentDownloadBytes)
        {
            EventSystem.Instance.Publish(self.Scene(),
                new ResourcesUpdateProgress()
                {
                    CurrentCount = currentDownloadCount,
                    TotalCount = totalDownloadCount,
                    CurrentBytes = currentDownloadBytes,
                    TotalBytes = totalDownloadBytes
                });
        }

        private static void OnDownloadOverCallback(this ResourcesUpdaterComponent self, bool isSucceed)
        {
            EventSystem.Instance.Publish(self.Scene(), new ResourcesUpdateOver() { Success = isSucceed });
        }

        private static void OnDownloadErrorCallback(this ResourcesUpdaterComponent self, string fileName, string error)
        {
            EventSystem.Instance.Publish(self.Scene(), new ResourcesUpdateFail() { FileName = fileName, Error = error });
        }
    }
}