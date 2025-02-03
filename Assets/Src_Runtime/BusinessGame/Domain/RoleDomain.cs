using System;
using UnityEngine;

namespace GB {
    public static class RoleDomain {
        public static RoleEntity Spawn(GameContext ctx, int typeID) {
            RoleEntity role = GameFactory.Role_Create(ctx);
            role.typeID = typeID;
            ctx.roleRepository.Add(role);
            return role;
        }

        public static void Move(RoleEntity role, Vector2 dir) {
            role.Move(dir);
        }

        public static void UnSpawn(GameContext ctx, RoleEntity role) {
            ctx.roleRepository.Remove(role);
            role.TearDown();
        }

        public static void ClearAll(GameContext ctx) {
            int len = ctx.roleRepository.TakeAll(out RoleEntity[] roles);
            for (int i = 0; i < len; i++) {
                RoleEntity role = roles[i];
                UnSpawn(ctx, role);
            }
        }

        // 捡起物品
        public static void PressEPick(GameContext ctx, RoleEntity role) {
            var bagCom = role.BagCom;
            var game = ctx.gameEntity;
            var stuff = game.currentStuff;
            if (stuff == null) {
                return;
            }

            // 拾取物品
            BagDomain.OnPick(ctx, role, stuff);
            game.currentStuff = null;
        }

        public static void PressESwitchingScenes(GameContext ctx, RoleEntity role) {
            var game = ctx.gameEntity;
            var step = game.currentStep;
            if (step == null) {
                return;
            }

            // 切换场景
            StepDomain.OnSwitchingScenes(ctx, role, step);
            game.currentStep = null;
        }

        #region Trigger

        public static void OnTriggerEnter(GameContext ctx, RoleEntity role, Collider2D other) {
            var ui = ctx.uiApp;
            var input = ctx.inputCore;

            if (other.CompareTag("Stuff")) {
                ui.Tip_PressE_Open(role);

                bool isOpen = ui.isPressEOpened();

                // 拾取物品
                if (isOpen) {
                    ctx.gameEntity.currentStuff = other.GetComponent<StuffEntity>();
                    ctx.gameEntity.currentStep = null;
                }

            } else if (other.CompareTag("Step")) {
                ui.Tip_PressE_Open(role);

                bool isOpen = ui.isPressEOpened();

                if (isOpen) {
                    ctx.gameEntity.currentStep = other.GetComponent<StepEntity>();
                    ctx.gameEntity.currentStuff = null;
                }

            }
        }

        public static void OnTriggerExit(GameContext ctx, Collider2D other) {
            if (other.CompareTag("Stuff")) {
                ctx.uiApp.Tip_PressE_Close();
            } else if (other.CompareTag("Step")) {
                ctx.uiApp.Tip_PressE_Close();
            }
        }

        #endregion 
    }
}