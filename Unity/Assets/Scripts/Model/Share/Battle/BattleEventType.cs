namespace ET
{
    public struct CastStart
    {
        public long CasterId;
        public int CastConfigId;
        public long CastId;
    }

    public struct CastHit
    {
        public long CasterId;
        public long TargetId;
        public long CastId;
    }
    
    public struct CastFinish
    {
        public long CasterId;
        public long CastId;
    }
    
    public struct CastBreak
    {
        public long CasterId;
        public long CastId;
    }
    
    public struct BuffAdd
    {
        public Unit Unit;
        public long BuffId;
        public int BuffConfigId;
    }
    
    public struct BuffRemove
    {
        public Unit Unit;
        public long BuffId;
    }
    
    public struct BuffTick
    {
        public Unit Unit;
        public long BuffId;
    }
    
    public struct BuffUpdate
    {
        public Unit Unit;
        public long BuffId;
        public int BuffConfigId;
    }

    public struct BuffTimeout
    {
        public Unit Unit;
        public long BuffId;
    }
}