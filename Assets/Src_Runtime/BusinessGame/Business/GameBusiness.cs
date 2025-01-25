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

            //typeID不对，晚点改
            RoleDomain.Spawn(ctx, game.ownerID);
            
            //TODO: 游戏关卡生成
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