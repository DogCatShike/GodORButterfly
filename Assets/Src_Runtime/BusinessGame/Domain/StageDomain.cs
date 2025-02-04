using System;
using UnityEngine;

namespace GB
{
    public static class StageDomain
    {
        public static StageEntity Spawn(GameContext ctx, int stageID)
        {
            StageEntity stage = GameFactory.Stage_Create(ctx, stageID);
            ctx.stageRepository.Add(stage);
            return stage;
        }

        public static void UnSpawn(GameContext ctx, StageEntity stage)
        {
            ctx.stageRepository.Remove(stage);
            stage.TearDown();
        }

        public static void ClearAll(GameContext ctx)
        {
            int len = ctx.stageRepository.TakeAll(out StageEntity[] stages);
            for (int i = 0; i < len; i++)
            {
                StageEntity stage = stages[i];
                UnSpawn(ctx, stage);
            }
        }

        public static void AddStuff(StageEntity stage, StuffEntity stuff)
        {
            stage.AddStuff(stuff);
        }

        public static void AddInteraction(StageEntity stage, InteractionEntity interaction)
        {
            stage.AddInteraction(interaction);
        }

        public static void RemoveStuff(StageEntity stage, StuffEntity stuff)
        {
            stage.RemoveStuff(stuff);
        }

        public static void RemoveInteraction(StageEntity stage, InteractionEntity interaction)
        {
            stage.RemoveInteraction(interaction);
        }

        public static bool TryGetStuff(StageEntity stage, int typeID, out bool isPicked)
        {
            return stage.TryGetStuff(typeID, out isPicked);
        }

        public static bool TryGetInteraction(StageEntity stage, int typeID, out int times)
        {
            return stage.TryGetInteraction(typeID, out times);
        }

        public static void Clear(StageEntity stage)
        {
            stage.Clear();
        }
    }
}