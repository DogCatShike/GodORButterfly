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
            // 切换场景前逻辑
            Debug.Log("切换场景");

            var game = ctx.gameEntity;
            var map = ctx.Get_Map();
            int stageID = map.stageID;

            if (!ctx.stageRepository.TryGet(stageID, out StageEntity stageEntity))
            {
                StageDomain.Spawn(ctx, stageID);
            }

            var oldStage = ctx.Get_Stage();

            if (step.typeID == 0)
            {
                stageID += 1;
            }
            else if (step.typeID == 1)
            {
                stageID -= 1;
            }
            ctx.gameEntity.mapID = stageID;
            
            int stuffLen = ctx.stuffRepository.TakeAll(out StuffEntity[] stuffs);
            for (int i = 0; i < stuffLen; i++)
            {
                StuffEntity stuff = stuffs[i];

                bool hasStuff = StageDomain.TryGetStuff(oldStage, stuffs[i].typeID, out bool isPicked);
                if (hasStuff)
                {
                    StageDomain.RemoveStuff(oldStage, stuff);
                }
                StageDomain.AddStuff(oldStage, stuff);
            }

            int interactionLen = ctx.interactionRepository.TakeAll(out InteractionEntity[] interactions);
            for (int i = 0; i < interactionLen; i++)
            {
                InteractionEntity interaction = interactions[i];

                bool hasInteraction = StageDomain.TryGetInteraction(oldStage, interactions[i].typeID, out int times);
                if (hasInteraction)
                {
                    StageDomain.RemoveInteraction(oldStage, interaction);
                }
                StageDomain.AddInteraction(oldStage, interaction);
            }

            StuffDomain.ClearAll(ctx);
            StepDomain.ClearAll(ctx);
            InteractionDomain.ClearAll(ctx);

            // 切换场景后逻辑
            var stage = ctx.Get_Stage();
            if (stage == null)
            {
                stage = StageDomain.Spawn(ctx, stageID);
            }

            bool has = ctx.templateCore.TryGetStage(stageID, out StageTM tm);

            MapDomain.Spawn(ctx, stageID);

            for (int i = 0; i < tm.stuffSpawns.Length; i++)
            {
                StuffSpawnTM spawnTM = tm.stuffSpawns[i];

                bool hasStuff = StageDomain.TryGetStuff(stage, spawnTM.so.tm.typeID, out bool isPicked);
                    
                if (hasStuff)
                {
                    if (spawnTM.so.tm.spawnStageID == game.mapID && !isPicked)
                    {
                        StuffDomain.SpawnBySpawn(ctx, spawnTM.so.tm.typeID, spawnTM);
                    }
                }
                else
                {
                    if (spawnTM.so.tm.spawnStageID == game.mapID)
                    {
                        StuffDomain.SpawnBySpawn(ctx, spawnTM.so.tm.typeID, spawnTM);
                    }
                }
            }

            if (tm.interactionSpawns != null)
            {
                for (int i = 0; i < tm.interactionSpawns.Length; i++)
                {
                    InteractionSpawnTM spawnTM = tm.interactionSpawns[i];

                    if (spawnTM.so.tm.spawnStageID == game.mapID)
                    {
                        InteractionEntity interaction = InteractionDomain.SpawnBySpawn(ctx, spawnTM.so.tm.typeID, spawnTM);
                        bool hasInteraction = StageDomain.TryGetInteraction(stage, interaction.typeID, out int times);
                        if (hasInteraction)
                        {
                            interaction.times = times;
                        }
                    }
                }
            }

            StepDomain.SpawnBySpawn(ctx, tm.stepSpawn);
            MapDomain.UnSpawn(ctx, map);

            // 玩家要重置位置吗?
        }
    }
}