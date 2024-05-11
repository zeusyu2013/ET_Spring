namespace ET.Server
{
    [EntitySystemOf(typeof(ChatComponent))]
    public static partial class ChatComponentSystem
    {
        [EntitySystem]
        private static void Awake(this ET.Server.ChatComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this ET.Server.ChatComponent self)
        {
        }

        public static void Broadcast(this ChatComponent self, int channelId, string content)
        {
            if (channelId < 1)
            {
                return;
            }

            if (string.IsNullOrEmpty(content))
            {
                return;
            }

            foreach (StartSceneConfig config in StartSceneConfigCategory.Instance.Maps)
            {
                M2M_ChatBroadcast m2MChatBroadcast = M2M_ChatBroadcast.Create();
                m2MChatBroadcast.ChannelId = channelId;
                m2MChatBroadcast.Content = content;
                self.Root().GetComponent<MessageSender>().Send(config.ActorId, m2MChatBroadcast);
            }
        }
    }
}