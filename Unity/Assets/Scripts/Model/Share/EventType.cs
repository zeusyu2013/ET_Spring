namespace ET.Client
{
    public struct SceneChangeStart
    {
    }
    
    public struct SceneChangeFinish
    {
    }
    
    public struct AfterCreateClientScene
    {
    }
    
    public struct AfterCreateCurrentScene
    {
    }

    public struct AppStartInitFinish
    {
    }

    public struct LoginFinish
    {
        public long UnitId;
    }

    public struct UIPing
    {
        public long Ping;
    }
    

    public struct ChooseServer
    {
        
    }

    public struct JoystickMove
    {
        public bool IsMove;
        public float DeltaX;
        public float DeltaY;
    }

    public struct GetRolesFinish
    {
        
    }

    public struct EnterMapFinish
    {
    }

    public struct AfterUnitCreate
    {
        public Unit Unit;
    }

    public struct AfterItemAdd
    {
        
    }

    public struct BeforeItemRemove
    {
        
    }

    public struct AfterItemRemove
    {
        
    }

    public struct OnItemUsed
    {
        
    }
}