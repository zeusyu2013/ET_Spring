namespace ET.Server
{
    [DBVersion(DBVersionEnum.Version1)]
    public static class DBVersion1
    {
        public static async ETTask Init(int zone)
        {
            await ETTask.CompletedTask;
        }
    }
}