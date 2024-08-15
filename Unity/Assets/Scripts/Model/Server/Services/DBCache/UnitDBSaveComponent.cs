using System;
using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Unit))]
    public class UnitDBSaveComponent : Entity, IAwake, IDestroy
    {
        public HashSet<Type> EntityChangeTypes = new();

        public long Timer;
    }
}