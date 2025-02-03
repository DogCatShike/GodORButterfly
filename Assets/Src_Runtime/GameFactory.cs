using System;
using Unity.VisualScripting;
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
            role.OnTriggerEnterHandle = (role, other) =>
            {
                RoleDomain.OnTriggerEnter(ctx, role, other);
            };
            role.OnTriggerExitHandle = (role, other) =>
            {
                RoleDomain.OnTriggerExit(ctx, other);
            };
            role.Init(5);

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

        public static StuffEntity Stuff_CreateBySpawn(GameContext ctx, StuffSpawnTM spawnTM)
        {
            int typeID = spawnTM.so.tm.typeID;

            bool has = ctx.templateCore.TryGetStuff(typeID, out var tm);
            if (!has)
            {
                Debug.LogError("Stuff_Create: tm is null" + typeID);
                return null;
            }
            GameObject prefab = ctx.assetsCore.Entity_GetStuff(tm.typeID);
            GameObject go = GameObject.Instantiate(prefab);
            StuffEntity stuff = go.GetComponent<StuffEntity>();

            string n = "Entity_Stuff_" + tm.typeName;
            if (go.name != n)
            {
                go.name = n;
            }

            stuff.Ctor();
            stuff.idSig = ctx.gameEntity.stuffID;
            stuff.typeID = tm.typeID;
            stuff.description = tm.description;

            stuff.icon = tm.sprite;

            stuff.TF_Transfrom(spawnTM.position);
            stuff.TF_Rotation(spawnTM.rotation);

            return stuff;
        }

        public static StepEntity Step_CreateBySpawn(GameContext ctx, StepSpawnTM spawnTM)
        {
            int typeID = spawnTM.so.tm.typeID;

            bool has = ctx.templateCore.TryGetStep(typeID, out var tm);
            if (!has)
            {
                Debug.LogError("Step_Create: tm is null" + typeID);
                return null;
            }
            GameObject prefab = ctx.assetsCore.Entity_GetStep(tm.typeID);
            GameObject go = GameObject.Instantiate(prefab);
            StepEntity step = go.GetComponent<StepEntity>();

            step.Ctor();
            step.idSig = ctx.gameEntity.stepID;
            step.typeID = tm.typeID;

            step.TF_Transfrom(spawnTM.position);
            step.TF_Rotation(spawnTM.rotation);

            return step;
        }
    }
}