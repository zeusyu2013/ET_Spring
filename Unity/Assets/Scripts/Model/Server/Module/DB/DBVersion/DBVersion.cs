namespace ET.Server
{
    public enum DBVersionEnum
    {
        Version1 = 1,
        Version2,
        Version3,
    }

    public class DBVersion : Entity, IAwake
    {
    }
}