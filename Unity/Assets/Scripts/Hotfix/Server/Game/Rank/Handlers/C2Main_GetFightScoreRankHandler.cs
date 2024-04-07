using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Main)]
    [FriendOf(typeof(FightScoreRankComponent))]
    public class C2Main_GetFightScoreRankHandler : MessageHandler<Scene, C2Main_GetFightScoreRank, Main2C_GetFightScoreRank>
    {
        protected override async ETTask Run(Scene scene, C2Main_GetFightScoreRank request, Main2C_GetFightScoreRank response)
        {
            List<FightScoreRankEntityInfo> entities = new();
            foreach ((long id, long score) in scene.GetComponent<FightScoreRankComponent>().GetRanks())
            {
                FightScoreRankEntityInfo info = FightScoreRankEntityInfo.Create();
                info.UnitId = id;
                info.FightScore = score;
                entities.Add(info);
            }

            response.FightScoreRankEntityInfos = entities;

            await ETTask.CompletedTask;
        }
    }
}