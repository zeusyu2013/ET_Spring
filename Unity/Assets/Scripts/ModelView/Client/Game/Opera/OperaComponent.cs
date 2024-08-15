namespace ET.Client
{
    [ComponentOf(typeof (Scene))]
    public class OperaComponent: Entity, IAwake, IUpdate
    {
        public C2M_PathfindingResult Result;
    }
}