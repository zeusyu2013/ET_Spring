namespace ET.Server
{
    public static class TDHelper
    {
        public static void SendUserAddToTDLog(Scene scene, TDUserAdd userAdd)
        {
            MapMessageHelper.Send(scene, StartSceneConfigCategory.Instance.TDLog.ActorId, userAdd);
        }

        public static void SendUserSetToTDLog(Scene scene, TDUserSet userSet)
        {
            MapMessageHelper.Send(scene, StartSceneConfigCategory.Instance.TDLog.ActorId, userSet);
        }
        
        public static void SendUserSetOnceToTDLog(Scene scene, TDUserSetOnce userSetOnce)
        {
            MapMessageHelper.Send(scene, StartSceneConfigCategory.Instance.TDLog.ActorId, userSetOnce);
        }

        public static void SendTrackToTDLog(Scene scene, TDTrack track)
        {
            MapMessageHelper.Send(scene, StartSceneConfigCategory.Instance.TDLog.ActorId, track);
        }
    }
}