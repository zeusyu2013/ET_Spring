using System;

namespace ET.Server
{
    [AttributeUsage(AttributeTargets.Class)]
    public class UnitCacheEventAttribute : BaseAttribute
    {
        public Type Type { get; }

        public UnitCacheEventAttribute(Type type)
        {
            this.Type = type;
        }
    }
}

