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

        #region Bag

        public static void OnTriggerEnter(GameContext ctx, RoleEntity role, Collider2D other) {

            StuffEntity stuff = other.GetComponent<StuffEntity>();

            var bagCom = role.BagCom;

            if (stuff != null) {
                // 1. 拾取物品
                bool isPicked = bagCom.Add(stuff.typeID, stuff.count, () => {
                    BagItemModel item = new BagItemModel();
                    // 从模板表里读取物品信息 stuffEntity相当于模板表

                    item.id = ctx.gameEntity.itemIDRecord++;
                    item.typeID = stuff.typeID;
                    item.count = stuff.count;
                    item.icon = stuff.icon;
                    return item;
                });

                if (isPicked) {
                    // 2. 移除 Stuff
                    StuffDomain.UnSpawn(ctx, stuff);
                    Debug.Log("拾取物品成功");
                }
                // 3. 如果背包是打开着的, 则刷新背包
                BagDomain.Update(ctx, bagCom);
            }

        }

        #endregion 
    }
}