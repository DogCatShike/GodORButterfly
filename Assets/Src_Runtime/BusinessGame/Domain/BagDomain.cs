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
            var game = ctx.gameEntity;
            // 空格子
            ui.Bag_Open(bag.GetMaxSlot());

            // 每个格子上的物品

            bag.ForEach(item => {
                ui.Bag_Add(item.id, item.icon, item.count);
            });

            bag.TryGet(game.currentStuffID, out BagItemModel stuff);

            if (stuff != null) {
                ui.Bag_SetTextSprite(stuff.description, stuff.icon);
            }

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
            InteractionEntity interaction = ctx.gameEntity.currentInteraction;

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

            if (interaction == null) {
                Debug.LogError("找不到交互: ");
                owner.Panel_CantUse_Show(ctx);
                return;
            }

            int typeID = interaction.typeID;

            if (typeID != item.typeID) {
                Debug.Log("物品类型不匹配");
                owner.Panel_CantUse_Show(ctx);
                return;
            }

            if (interaction.times <= 0) {
                Debug.Log("交互次数不足");
                owner.Panel_CantUse_Show(ctx);
                return;
            }

            // 使用物品
            // TODO：根据物品类型，执行不同的逻辑
            Debug.Log("使用物品  ");
            if (item.spawnTM != null)
            {
                StuffDomain.SpawnBySpawn(ctx, 0, item.spawnTM); // typeID可以删掉
            }

            interaction.times -= 1;
            owner.BagCom.Remove(id);
            Update(ctx, owner.BagCom);
        }

        // 拾取物品
        public static void OnPick(GameContext ctx, RoleEntity role, StuffEntity stuff) {
            var bagCom = role.BagCom;
            var game = ctx.gameEntity;
            var stage = ctx.Get_Stage();

            // 1. 拾取物品
            bool isPicked = bagCom.Add(stuff.typeID, stuff.count, () => {
                BagItemModel item = new BagItemModel();
                // 从模板表里读取物品信息 stuffEntity相当于模板表

                item.id = ctx.gameEntity.itemIDRecord++;
                item.typeID = stuff.typeID;
                item.count = stuff.count;
                item.icon = stuff.icon;
                item.description = stuff.description;
                if (stuff.spawnTM.so != null)
                {
                    item.spawnTM = stuff.spawnTM;
                }
                return item;
            });

            if (isPicked) {
                // 2. 移除 Stuff
                bool hasStuff = StageDomain.TryGetStuff(stage, stuff.typeID, out bool isPickedInStage);
                if (hasStuff)
                {
                    StageDomain.RemoveStuff(stage, stuff);
                }
                stuff.isPicked = true;
                StageDomain.AddStuff(stage, stuff);
                
                StuffDomain.UnSpawn(ctx, stuff);
                game.currentStuffID = 0;
            }
            // 3. 如果背包是打开着的, 则刷新背包
            Update(ctx, bagCom);
        }
    }
}