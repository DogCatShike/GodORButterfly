using System;
using UnityEngine;

namespace GB {
    public static class StuffDomain {
        public static StuffEntity SpawnBySpawn(GameContext ctx, int typeID, StuffSpawnTM spawnTM) {
            StuffEntity stuff = GameFactory.Stuff_CreateBySpawn(ctx, spawnTM);
            ctx.stuffRepository.Add(stuff);
            return stuff;
        }


        public static void UnSpawn(GameContext ctx, StuffEntity stuff) {
            ctx.stuffRepository.Remove(stuff);
            stuff.TearDown();
        }

        public static void ClearAll(GameContext ctx) {
            int len = ctx.stuffRepository.TakeAll(out StuffEntity[] stuffs);
            for (int i = 0; i < len; i++) {
                StuffEntity stuff = stuffs[i];
                UnSpawn(ctx, stuff);
            }
        }
    }
}