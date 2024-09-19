namespace ET.Client
{
    [Event(SceneType.Main)]
    public class ResourcesUpdateProgressHandler : AEvent<Scene, ResourcesUpdateProgress>
    {
        protected override async ETTask Run(Scene scene, ResourcesUpdateProgress args)
        {
            int currentCount = args.CurrentCount;
            int totalCount = args.TotalCount;
            long currentBytes = args.CurrentBytes;
            long totalBytes = args.TotalBytes;

            // todo:progressbar上显示{currentCount}/{totalCount},{FormatBytes(currentBytes)}/{FormatBytes(totalBytes)}

            await ETTask.CompletedTask;
        }

        private string FormatBytes(long bytes)
        {
            double[] byteUnits =
            {
                1073741824.0, 1048576.0, 1024.0, 1
            };

            string[] byteUnitsNames =
            {
                "GB", "MB", "KB", "B"
            };

            var size = "0 B";
            if (bytes == 0)
            {
                return size;
            }

            for (var index = 0; index < byteUnits.Length; index++)
            {
                var unit = byteUnits[index];
                if (!(bytes >= unit))
                {
                    continue;
                }

                size = $"{bytes / unit:##.##} {byteUnitsNames[index]}";
                break;
            }

            return size;
        }
    }
}