using System;
using UnityEngine;

namespace GB
{
    public static class GameFactory
    {
        public static RoleEntity Role_Create(GameContext ctx)
        {
            GameObject prefab = ctx.assetsCore.Entity_GetRole();
            if (prefab == null)
            {
                Debug.LogError("Role prefab is null");
            }

            RoleEntity role = GameObject.Instantiate(prefab).GetComponent<RoleEntity>();
            role.Ctor();
            role.idSig = ctx.gameEntity.ownerID;

            return role;
        }

        public static MapEntity Map_Create(GameContext ctx, int stageID)
        {
            GameObject prefab = ctx.assetsCore.Entity_GetMap(stageID);
            if (prefab == null)
            {
                Debug.LogError("Map prefab is null");
            }

            MapEntity map = GameObject.Instantiate(prefab).GetComponent<MapEntity>();
            map.Ctor();
            map.stageID = stageID;
            ctx.gameEntity.mapID = map.stageID;

            return map;
        }

        //这段感觉没必要留了
        public static StuffEntity Stuff_Create(GameContext ctx, int typeID)
        {
            GameObject prefab = ctx.assetsCore.Entity_GetStuff(typeID);
            if (prefab == null)
            {
                Debug.LogError("Stuff prefab is null");
            }

            StuffEntity stuff = GameObject.Instantiate(prefab).GetComponent<StuffEntity>();
            stuff.Ctor();
            stuff.typeID = typeID;
            ctx.gameEntity.stuffID = stuff.typeID;

            return stuff;
        }

        public static StuffEntity Stuff_CreateBySpawn(GameContext ctx, StuffSpawnTM spawnTM)
        {
            // 这样写?
            GameObject prefab = ctx.assetsCore.Entity_GetStuff(spawnTM.so.tm.typeID);
            if (prefab == null)
            {
                Debug.LogError("Stuff prefab is null");
            }

            StuffEntity stuff = GameObject.Instantiate(prefab).GetComponent<StuffEntity>();
            stuff.Ctor();
            stuff.idSig = ctx.gameEntity.stuffID;

            stuff.TF_Transfrom(spawnTM.position);
            stuff.TF_Rotation(spawnTM.rotation);

            return stuff;
        }

        public static StepEntity Step_CreateBySpawn(GameContext ctx, StepSpawnTM spawnTM)
        {
            GameObject prefab = ctx.assetsCore.Entity_GetStep();
            if (prefab == null)
            {
                Debug.LogError("Step prefab is null");
            }

            StepEntity step = GameObject.Instantiate(prefab).GetComponent<StepEntity>();
            step.Ctor();
            step.idSig = ctx.gameEntity.stepID;

            step.TF_Transfrom(spawnTM.position);
            step.TF_Rotation(spawnTM.rotation);

            return step;
        }
    }
}