namespace ET.Server
{
    public struct BagOnAdd
    {
        public Unit Unit;
        public GameItem GameItem;
        public long OldAmount;
        public long NewAmount;
    }

    public struct BagOnRemove
    {
        public Unit Unit;
        public int GameItemConfig;
        public long OldAmount;
        public long NewAmount;
    }
}