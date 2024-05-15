namespace ET.Server
{
    public enum DBVersionEnum
    {
        Version1 = 1,
        Version2,
        Version3,
    }

    [ComponentOf(typeof(Unit))]
    public class DBVersion : Entity, IAwake
    {
        public int DBVersionNumber;
    }
}