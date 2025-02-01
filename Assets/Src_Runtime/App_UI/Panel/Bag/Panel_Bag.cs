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
                ele.Init(-1, null);
                ele.OnClickHandler += OnUse;
                elements.Add(ele);
            }
        }

        public void Close() {
            foreach (var element in elements) {
                Destroy(element.gameObject);
            }
            elements.Clear();
        }

        // 添加
        public void Add(int id, Sprite sprite) {
            // 逻辑: 找到非-1的空格子, 设置内容

        }
    }
}