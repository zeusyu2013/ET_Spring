
namespace ET.Client
{
    [ComponentOf]
    public class MapleComponent : Entity, IAwake, IDestroy
    {
        private MapleResponse mapleInfo = new();

        public MapleResponse MapleInfo
        {
            get { return mapleInfo; }
            set { mapleInfo = value; }
        }
        
    }
    
}
