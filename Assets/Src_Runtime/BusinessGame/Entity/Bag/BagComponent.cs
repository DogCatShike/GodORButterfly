using System;
using System.Collections;
using UnityEngine;


namespace GB {

    public class BagComponent {
        BagItemModel[] all;

        public BagComponent() {

        }

        public void Init(int maxSlot) {
            all = new BagItemModel[maxSlot];
        }

        // 是否添加成功
        public bool Add(int typeID, int count, Func<BagItemModel> onAddItemToNewSlot) {
            // 是否已存在相同 typeID
            for (int i = 0; i < all.Length; i += 1) {
                BagItemModel old = all[i];
                if (old != null && old.typeID == typeID) {
                    // 叠加
                    Debug.Log("叠加物品已经存在");
                    return false;
                }
            }

            // 并没有叠加在相同的 TypeID 上
            if (count > 0) {
                int index = -1;
                // 找到第一个空格子
                for (int i = 0; i < all.Length; i += 1) {
                    BagItemModel old = all[i];
                    if (old == null) {
                        index = i;
                        break;
                    }
                }

                // 如果没有空格子
                if (index == -1) {
                    return false;
                }

                // 在空格子里添加新的物品, 并设置数量
                BagItemModel model = onAddItemToNewSlot.Invoke();
                all[index] = model;
                return true;
            } else {
                return true;
            }

        }
        // 查找物品
        public bool TryGet(int id, out BagItemModel item) {
            for (int i = 0; i < all.Length; i += 1) {
                BagItemModel model = all[i];
                if (model != null && model.id == id) {
                    item = model;
                    return true;
                }
            }
            item = null;
            return false;
        }

        // 移除物品
        public bool Remove(int id) {
            for (int i = 0; i < all.Length; i += 1) {
                BagItemModel model = all[i];
                if (model != null && model.id == id) {
                    all[i] = null;
                    return true;
                }
            }
            return false;
        }

        // 遍历物品
        public void ForEach(Action<BagItemModel> callback) {
            for (int i = 0; i < all.Length; i += 1) {
                BagItemModel item = all[i];
                if (item != null) {
                    callback.Invoke(item);
                }
            }
        }
        
    }

}