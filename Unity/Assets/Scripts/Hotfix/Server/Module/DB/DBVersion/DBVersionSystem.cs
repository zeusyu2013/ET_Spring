namespace ET.Server
{
    [EntitySystemOf(typeof(DBVersion))]
    public static partial class DBVersionSystem
    {
        public static void Awake(this DBVersion self)
        {
        }
    }
}