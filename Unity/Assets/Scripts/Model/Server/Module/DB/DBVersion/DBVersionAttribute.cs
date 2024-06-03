using System;

namespace ET.Server
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DBVersionAttribute : BaseAttribute
    {
        public DBVersionEnum DBVersionEnum;

        public DBVersionAttribute(DBVersionEnum dbVersionEnum)
        {
            this.DBVersionEnum = dbVersionEnum;
        }
    }
}