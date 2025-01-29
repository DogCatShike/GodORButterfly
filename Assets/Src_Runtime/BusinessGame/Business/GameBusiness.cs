using System;
using UnityEngine;

namespace GB
{
    public static class GameBusiness
    {
        public static void Enter(GameContext ctx)
        {
            var game = ctx.gameEntity;
            game.state = GameState.Game;

            //typeID这样写?
            RoleDomain.Spawn(ctx, 1);

            bool has = ctx.templateCore.TryGetStage(11, out StageTM tm);
            MapDomain.Spawn(ctx, 11);
        }

        public static void Tick(GameContext ctx, float dt)
        {

        }

        public static void PreTick(GameContext ctx, float dt)
        {

        }

        public static void LogicTick(GameContext ctx, float dt)
        {

        }

        public static void LastTick(GameContext ctx, float dt)
        {

        }
    }
}