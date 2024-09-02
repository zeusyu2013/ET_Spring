﻿
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
    
    public struct GetAllItems
    {
        public M2C_GetAllItems message;
    }

    public struct JoystickMove
    {
        public float DeltaX;
        public float DeltaY;
    }
}