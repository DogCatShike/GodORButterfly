using System;
using UnityEngine;

namespace GB
{
    public static class StepDomain
    {
        public static StepEntity SpawnBySpawn(GameContext ctx, StepSpawnTM spawnTM)
        {
            StepEntity step = GameFactory.Step_CreateBySpawn(ctx, spawnTM);
            ctx.stepRepository.Add(step);
            return step;
        }

        public static void UnSpawn(GameContext ctx, StepEntity step)
        {
            ctx.stepRepository.Remove(step);
            step.TearDown();
        }

        public static void ClearAll(GameContext ctx)
        {
            int len = ctx.stepRepository.TakeAll(out StepEntity[] steps);
            for (int i = 0; i < len; i++)
            {
                StepEntity step = steps[i];
                UnSpawn(ctx, step);
            }
        }

        public static void OnSwitchingScenes(GameContext ctx, RoleEntity role, StepEntity step)
        {
            Debug.Log("切换场景");

            var game = ctx.gameEntity;
            var map = ctx.Get_Map();
            int stageID = map.stageID;

            if (step.typeID == 0)
            {
                stageID += 1;
            }
            else if (step.typeID == 1)
            {
                stageID -= 1;
            }

            StuffDomain.ClearAll(ctx);
            StepDomain.ClearAll(ctx);

            bool has = ctx.templateCore.TryGetStage(stageID, out StageTM tm);
            MapDomain.Spawn(ctx, stageID);
            for (int i = 0; i < tm.stuffSpawns.Length; i++)
            {
                StuffSpawnTM spawnTM = tm.stuffSpawns[i];

                if (spawnTM.so.tm.spawnStageID == game.mapID)
                {
                    StuffDomain.SpawnBySpawn(ctx, spawnTM.so.tm.typeID, spawnTM);
                }
            }
            StepDomain.SpawnBySpawn(ctx, tm.stepSpawn);
            MapDomain.UnSpawn(ctx, map);

            // 玩家要重置位置吗?
            // TODO: 判断物品是否被拾取，已拾取则不生成
        }
    }
}