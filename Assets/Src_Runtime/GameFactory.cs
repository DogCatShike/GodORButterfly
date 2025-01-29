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
            map.Ctor(); // 为什么这行报错空引用?
            map.stageID = stageID;
            ctx.gameEntity.mapID = map.stageID;

            return map;
        }
    }
}