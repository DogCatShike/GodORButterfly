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

            if (tm.interactionSpawns != null) {
                for (int i = 0; i < tm.interactionSpawns.Length; i++) {
                    InteractionSpawnTM spawnTM = tm.interactionSpawns[i];

                    if (spawnTM.so.tm.spawnStageID == game.mapID) {
                        InteractionDomain.SpawnBySpawn(ctx, spawnTM.so.tm.typeID, spawnTM);
                    }
                }
            }

            StepEntity step = StepDomain.SpawnBySpawn(ctx, tm.stepSpawn);

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

            // 拾取物品
            if (input.isKeyDownE) {
                RoleDomain.PressEPick(ctx, role);
                RoleDomain.PressESwitchingScenes(ctx, role);
            }

            // bag
            BagComponent bag = role.BagCom;
            if (input.isKeyDownTab) {
                BagDomain.Toogle(ctx, bag);
            }

            if (input.isKeyDownEsc) {
                ctx.uiApp.Panel_PauseGame_Open();
                Time.timeScale = 0;
            }

            if (input.isKeyEnter) {
                RoleDomain.RoleUseStuff(ctx, role);
            }

            // Camera
            MapEntity map = ctx.Get_Map();
            GameObject bg = map.transform.Find("Follow").gameObject;
            CameraDomain.FollowTarget(role.transform, bg, dt);
        }

        public static void LastTick(GameContext ctx, float dt) {

        }
    }
}