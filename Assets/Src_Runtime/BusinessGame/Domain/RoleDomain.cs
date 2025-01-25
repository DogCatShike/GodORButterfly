using System;
using UnityEngine;

namespace GB
{
    public static class RoleDomain
    {
        public static RoleEntity Spawn(GameContext ctx, int typeID)
        {
            RoleEntity role = GameFactory.Role_Create(ctx);
            role.typeID = typeID;
            ctx.roleRepository.Add(role);
            return role;
        }

        public static void UnSpawn(GameContext ctx, RoleEntity role)
        {
            ctx.roleRepository.Remove(role);
            role.TearDown();
        }

        public static void ClearAll(GameContext ctx)
        {
            int len = ctx.roleRepository.TakeAll(out RoleEntity[] roles);
            for (int i = 0; i < len; i++)
            {
                RoleEntity role = roles[i];
                UnSpawn(ctx, role);
            }
        }
    }
}