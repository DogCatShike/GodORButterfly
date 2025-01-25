using System;
using UnityEngine;

namespace GB
{
    public static class LoginBusiness
    {
        public static void Enter(GameContext ctx)
        {
            var game = ctx.gameEntity;
            game.state = GameState.LoginEnter;

            ctx.uiApp.Panel_StartGame_Open();
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