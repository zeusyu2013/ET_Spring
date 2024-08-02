
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;

namespace ET
{
    [EnableClass]
    public sealed partial class AttractParams : ActionParam
    {
        public AttractParams(ByteBuf _buf) : base(_buf) 
        {
            AttractRange = _buf.ReadFloat();
            AttractSpeed = _buf.ReadFloat();

            PostInit();
        }

        public static AttractParams DeserializeAttractParams(ByteBuf _buf)
        {
            return new AttractParams(_buf);
        }

        public readonly float AttractRange;

        public readonly float AttractSpeed;

        public const int __ID__ = 746462663;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "AttractRange:" + AttractRange + ","
            + "AttractSpeed:" + AttractSpeed + ","
            + "}";
        }

        partial void PostInit();
    }
}
