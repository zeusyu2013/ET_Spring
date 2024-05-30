using System;

namespace ET.Client
{
    [Serializable]
    public struct RoleLogin
    {
        public long role_id;
        public string role_name;
        public int server_id;
        public string server_name;
    }
}