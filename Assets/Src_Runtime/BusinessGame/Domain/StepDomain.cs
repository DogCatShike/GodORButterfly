using System;
using UnityEngine;

namespace GB {
    public static class StepDomain {
        public static StepEntity SpawnBySpawn(GameContext ctx, StepSpawnTM spawnTM) {
            StepEntity step = GameFactory.Step_CreateBySpawn(ctx, spawnTM);
            ctx.stepRepository.Add(step);
            return step;
        }

        public static void UnSpawn(GameContext ctx, StepEntity step) {
            ctx.stepRepository.Remove(step);
            step.TearDown();
        }

        public static void ClearAll(GameContext ctx) {
            int len = ctx.stepRepository.TakeAll(out StepEntity[] steps);
            for (int i = 0; i < len; i++) {
                StepEntity step = steps[i];
                UnSpawn(ctx, step);
            }
        }

        public static void OnSwitchingScenes(GameContext ctx, RoleEntity role, StepEntity step) {
            Debug.Log("切换场景");
        }
    }
}