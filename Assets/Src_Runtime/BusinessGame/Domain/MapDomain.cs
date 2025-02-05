using System;
using UnityEngine;

namespace GB
{
    public static class MapDomain
    {
        public static MapEntity Spawn(GameContext ctx, int stageID)
        {
            MapEntity map = GameFactory.Map_Create(ctx, stageID);
            ctx.mapRepository.Add(map);
            return map;
        }

        public static void UnSpawn(GameContext ctx, MapEntity map)
        {
            ctx.mapRepository.Remove(map);
            map.TearDown();
        }

        public static void ClearAll(GameContext ctx)
        {
            int len = ctx.mapRepository.TakeAll(out MapEntity[] maps);
            for (int i = 0; i < len; i++)
            {
                MapEntity map = maps[i];
                UnSpawn(ctx, map);
            }
        }

        public static void NextStage(GameContext ctx)
        {
            RoleDomain.ClearAll(ctx);
            StuffDomain.ClearAll(ctx);
            StepDomain.ClearAll(ctx);
            InteractionDomain.ClearAll(ctx);
            MapDomain.ClearAll(ctx);
            StageDomain.ClearAll(ctx);

            var game = ctx.gameEntity;
            int maxStage = game.maxStage;
            int stageID = game.mapID;
            stageID = stageID / 10;

            if (stageID < maxStage)
            {
                stageID += 1;
                RoleDomain.Spawn(ctx, stageID);

                stageID = stageID * 10 + 1;
                game.mapID = stageID;

                bool has = ctx.templateCore.TryGetStage(stageID, out StageTM tm);
                MapDomain.Spawn(ctx, stageID);

                StageEntity stage = StageDomain.Spawn(ctx, stageID);

                for (int i = 0; i < tm.stuffSpawns.Length; i++)
                {
                    StuffSpawnTM spawnTM = tm.stuffSpawns[i];

                    if (spawnTM.so.tm.spawnStageID == game.mapID)
                    {
                        StuffEntity stuff = StuffDomain.SpawnBySpawn(ctx, spawnTM.so.tm.typeID, spawnTM);
                    }
                }

                if (tm.interactionSpawns != null)
                {
                    for (int i = 0; i < tm.interactionSpawns.Length; i++)
                    {
                        InteractionSpawnTM spawnTM = tm.interactionSpawns[i];

                        if (spawnTM.so.tm.spawnStageID == game.mapID)
                        {
                            InteractionDomain.SpawnBySpawn(ctx, spawnTM.so.tm.typeID, spawnTM);
                        }
                    }
                }

                StepEntity step = StepDomain.SpawnBySpawn(ctx, tm.stepSpawn);

                int stuffLen = ctx.stuffRepository.TakeAll(out StuffEntity[] stuffs);
                for (int i = 0; i < stuffLen; i++)
                {
                    bool hasStuff = StageDomain.TryGetStuff(stage, stuffs[i].typeID, out bool isPicked);
                    StuffEntity stuff = stuffs[i];
                    if (hasStuff)
                    {
                        StageDomain.RemoveStuff(stage, stuff);
                    }
                    StageDomain.AddStuff(stage, stuff);
                }

                int interactionLen = ctx.interactionRepository.TakeAll(out InteractionEntity[] interactions);
                for (int i = 0; i < interactionLen; i++)
                {
                    bool hasInteraction = StageDomain.TryGetInteraction(stage, interactions[i].typeID, out int times);
                    InteractionEntity interaction = interactions[i];
                    if (hasInteraction)
                    {
                        StageDomain.RemoveInteraction(stage, interaction);
                    }
                    StageDomain.AddInteraction(stage, interaction);
                }
            }
        }
    }
}