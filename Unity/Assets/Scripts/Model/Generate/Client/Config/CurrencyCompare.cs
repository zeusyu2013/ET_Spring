
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
    public sealed partial class CurrencyCompare : Condition
    {
        public CurrencyCompare(ByteBuf _buf) : base(_buf) 
        {
            CurrencyType = (CurrencyType)_buf.ReadInt();
            Value = _buf.ReadLong();

            PostInit();
        }

        public static CurrencyCompare DeserializeCurrencyCompare(ByteBuf _buf)
        {
            return new CurrencyCompare(_buf);
        }

        public readonly CurrencyType CurrencyType;

        public readonly long Value;

        public const int __ID__ = 600610676;

        public override int GetTypeId() => __ID__;

        public override string ToString()
        {
            return "{ "
            + "CurrencyType:" + CurrencyType + ","
            + "Value:" + Value + ","
            + "}";
        }

        partial void PostInit();
    }
}