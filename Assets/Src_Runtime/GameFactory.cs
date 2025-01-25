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
    }
}