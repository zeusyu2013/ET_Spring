namespace ET.Server
{
    [ChildOf]
    public class Friend : Entity, IAwake
    {
        public long UnitId;
        public string UnitName;
        public int UnitLevel;
        public string UnitIcon;
        public int Friendly;
    }
}