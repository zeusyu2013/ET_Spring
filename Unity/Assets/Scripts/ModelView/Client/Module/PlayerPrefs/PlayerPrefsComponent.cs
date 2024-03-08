using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class PlayerPrefsComponent : Entity, IAwake
    {
        // 上次登录的账号
        public string Account
        {
            get { return PlayerPrefs.GetString("Account", string.Empty); }

            set { PlayerPrefs.SetString("Account", value);}
        }

        // 上次登录成功的密码
        public string Passward
        {
            get { return PlayerPrefs.GetString("Passward", string.Empty); }
            set { PlayerPrefs.SetString("Passward", value);}
        }
        
        // Router地址
        public string RouterHttpHost
        {
            get { return PlayerPrefs.GetString("RouterHttpHost", string.Empty); }
            set { PlayerPrefs.SetString("RouterHttpHost", value);}
        }

        // Router 端口
        public string RouterHttpPort
        {
            get { return PlayerPrefs.GetString("RouterHttpPort", string.Empty); }
            set { PlayerPrefs.SetString("RouterHttpPort", value);}
        }

        public Servers ServerInfo
        {
            get
            {
                Servers serverInfo = new();
                serverInfo.server_addr = PlayerPrefs.GetString("Server_Ip", string.Empty);
                serverInfo.server_port = PlayerPrefs.GetInt("Server_Port", 0);
                serverInfo.server_id = PlayerPrefs.GetInt("Server_Id", 0);
                serverInfo.server_name = PlayerPrefs.GetString("Server_name",string.Empty);
                return serverInfo;
            }
            set
            {
                PlayerPrefs.SetString("Server_Ip", value.server_addr);
                PlayerPrefs.SetInt("Server_Port", value.server_port);
                PlayerPrefs.SetInt("Server_Id", value.server_id);
                PlayerPrefs.SetString("Server_name", value.server_name);
            }
        }
    }
}

