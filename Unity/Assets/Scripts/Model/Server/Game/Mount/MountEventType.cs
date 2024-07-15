namespace ET.Server
{
    public struct GetNewMount
    {
        public Unit Unit;
        public int MountConfigId;
        public int TotalMountCount;
    }
    
    public struct MountChanged
    {
        public Unit Unit;
        public int OldMount;
        public int NewMount;
    }
}