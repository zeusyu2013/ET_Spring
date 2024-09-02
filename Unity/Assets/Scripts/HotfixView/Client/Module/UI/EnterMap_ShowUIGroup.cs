﻿namespace ET.Client
{
    [Event(SceneType.MainClient)]
    public class EnterMap_ShowUIGroup : AEvent<Scene, EnterMapFinish>
    {
        protected override async ETTask Run(Scene scene, EnterMapFinish a)
        {
            UIHelper.OpenGroup(scene, UIDefine.UIGroupId.Common).Coroutine();
            await ETTask.CompletedTask;
        }
    }
}
