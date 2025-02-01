using System;
using UnityEngine;

namespace GB {
    public static class GameBusiness {
        public static void Enter(GameContext ctx) {
            var game = ctx.gameEntity;
            game.state = GameState.Game;

            //typeID这样写?
            RoleDomain.Spawn(ctx, 1);

            bool has = ctx.templateCore.TryGetStage(11, out StageTM tm);
            MapDomain.Spawn(ctx, 11);

            for (int i = 0; i < tm.stuffSpawns.Length; i++) {
                StuffSpawnTM spawnTM = tm.stuffSpawns[i];

                if (spawnTM.so.tm.spawnStageID == game.mapID) {
                    StuffEntity stuff = StuffDomain.SpawnBySpawn(ctx, spawnTM.so.tm.typeID, spawnTM);
                }
            }

            StepEntity step = StepDomain.SpawnBySpawn(ctx, tm.stepSpawn);

            BagDomain.Open(ctx);
        }

        public static void Tick(GameContext ctx, float dt) {
            PreTick(ctx, dt);

            ref float restFixTime = ref ctx.gameEntity.restFixTime;

            restFixTime += dt;
            const float FIX_INTERVAL = 0.020f;

            if (restFixTime <= FIX_INTERVAL) {

                LogicTick(ctx, restFixTime);

                restFixTime = 0;
            } else {
                while (restFixTime >= FIX_INTERVAL) {
                    LogicTick(ctx, FIX_INTERVAL);
                    restFixTime -= FIX_INTERVAL;
                }
            }

            LastTick(ctx, dt);
        }

        public static void PreTick(GameContext ctx, float dt) {
        }

        public static void LogicTick(GameContext ctx, float dt) {
            var input = ctx.inputCore;
            RoleEntity role = ctx.Get_Role();

            RoleDomain.Move(role, input.moveAxis);

            // bag
            BagComponent bag = role.Bag;
            if (input.isKeyDownTab) {
                BagDomain.Toogle(ctx, bag);
            }

        }

        public static void LastTick(GameContext ctx, float dt) {

        }
    }
}