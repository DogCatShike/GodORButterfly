using System;
using UnityEngine;

namespace GB
{
    public static class InteractionDomain
    {
        public static InteractionEntity SpawnBySpawn(GameContext ctx, int typeID, InteractionSpawnTM spawnTM)
        {
            InteractionEntity interaction = GameFactory.Interaction_CreateBySpawn(ctx, spawnTM);
            ctx.interactionRepository.Add(interaction);
            return interaction;
        }

        public static void UnSpawn(GameContext ctx, InteractionEntity interaction)
        {
            ctx.interactionRepository.Remove(interaction);
            interaction.TearDown();
        }

        public static void ClearAll(GameContext ctx)
        {
            int len = ctx.interactionRepository.TakeAll(out InteractionEntity[] interactions);
            for (int i = 0; i < len; i++)
            {
                InteractionEntity interaction = interactions[i];
                UnSpawn(ctx, interaction);
            }
        }
    }
}