namespace ET.Client
{
    public struct ResourcesUpdatePackageVersion
    {
        public bool Success;
        public string PackageVersion;
    }

    public struct ResourcesUpdateManifest
    {
        public bool Success;
    }

    public struct ResourcesUpdateNoResources
    {
        
    }
    
    public struct ResourcesUpdateBegin
    {
        public int TotalDownloadCount;
        public long TotalDownloadBytes;
    }
    
    public struct ResourcesUpdateStart
    {
        public string FileName;
        public long FileBytes;
    }

    public struct ResourcesUpdateProgress
    {
        public int CurrentCount;
        public int TotalCount;
        public long CurrentBytes;
        public long TotalBytes;
    }

    public struct ResourcesUpdateOver
    {
        public bool Success;
    }

    public struct ResourcesUpdateFail
    {
        public string FileName;
        public string Error;
    }
}