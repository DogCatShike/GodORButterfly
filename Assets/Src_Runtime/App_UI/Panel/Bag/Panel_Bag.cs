using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace GB {

    public class Panel_Bag : MonoBehaviour {

        [SerializeField] HorizontalLayoutGroup group;
        [SerializeField] Panel_BagElement elementPrefab;

        List<Panel_BagElement> elements;

        public Action<int> OnUseHandler;

        public void Ctor() {
            elements = new List<Panel_BagElement>();
        }

        void OnUse(int id) {
            OnUseHandler?.Invoke(id);
        }

        // maxSlot: 最大格子数
        public void Init(int maxSlot) {
            for (int i = 0; i < maxSlot; i++) {
                Panel_BagElement ele = Instantiate(elementPrefab, group.transform);
                ele.Ctor();
                ele.Init(-1, null, 1);
                ele.OnClickHandler += OnUse;
                elements.Add(ele);
            }
        }

        public void Close() {
            foreach (var ele in elements) {
                GameObject.Destroy(ele.gameObject);
            }
            GameObject.Destroy(gameObject);
        }

        // 添加
        public void Add(int id, Sprite sprite, int count) {
            // 逻辑: 找到非-1的空格子, 设置内容
            for (int i = 0; i < elements.Count; i++) {
                Panel_BagElement ele = elements[i];
                if (ele.id == -1) {
                    ele.Init(id, sprite, count);
                    break;
                }
            }
        }

        // 移除
        public void Remove(int id) {
            // 逻辑: 找到id相同的格子, 设置内容为空
            for (int i = 0; i < elements.Count; i++) {
                Panel_BagElement ele = elements[i];
                if (ele.id == id) {
                    ele.Init(-1, null, 0);
                    break;
                }
            }
        }

        public void Reomve2(int id) {
            int index = elements.FindIndex(ele => ele.id == id);
            if (index != -1) {
                GameObject.Destroy(elements[index].gameObject);
                elements.RemoveAt(index);
            }
        }

    }
}