using System;
using System.Collections;
using UnityEngine;


namespace GB {
    public class BagDomain {

        public static void Toogle(GameContext ctx, BagComponent bag) {
            var ui = ctx.uiApp;
            if (ui.Bag_IsOpened()) {
                ui.Bag_Close();
            } else {
                Open(ctx, bag);
            }
        }

        public static void Open(GameContext ctx, BagComponent bag) {
            var ui = ctx.uiApp;

            // 空格子
            ui.Bag_Open(bag.GetMaxSlot());

            // 每个格子上的物品

            bag.ForEach(item => {
                ui.Bag_Add(item.id, item.icon, item.count);
            });
        }

        // 更新背包
        public static void Update(GameContext ctx, BagComponent bag) {
            var ui = ctx.uiApp;
            if (ui.Bag_IsOpened()) {
                ui.Bag_Close();
                Open(ctx, bag);
            }
        }

        //使用物品 
        public static void OnOwnerUse(GameContext ctx, int id) {
            // 找到主角
            RoleEntity owner = ctx.Get_Role();

            if (owner == null) {
                Debug.LogError("找不到主角: ");
                return;
            }

            // 找到物品
            bool has = owner.BagCom.TryGet(id, out BagItemModel item);
            if (!has) {
                Debug.LogError("找不到物品: " + id);
                return;
            }

            // 使用物品
            // TODO：根据物品类型，执行不同的逻辑
        }
    }
}