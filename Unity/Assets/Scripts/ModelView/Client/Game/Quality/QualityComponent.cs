namespace ET.Client
{
    [ComponentOf]
    public class QualityComponent : Entity, IAwake, IDestroy
    {
        public QualityType QualityType;

        public QualityConfig QualityConfig;
    }
}