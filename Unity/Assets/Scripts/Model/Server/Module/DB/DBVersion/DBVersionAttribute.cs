namespace ET.Server
{
    public class DBVersionAttribute : BaseAttribute
    {
        public DBVersionEnum DBVersionEnum;

        public DBVersionAttribute(DBVersionEnum dbVersionEnum)
        {
            this.DBVersionEnum = dbVersionEnum;
        }
    }
}