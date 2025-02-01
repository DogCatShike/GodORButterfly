using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GB {

    public class Panel_BagElement : MonoBehaviour {

        public int id;

        [SerializeField] Image imageIcon;
        [SerializeField] Button btn;

        public Action<int> OnClickHandler;

        public void Ctor() {
            btn.onClick.AddListener(() => {
                OnClickHandler?.Invoke(id);
            });
        }

        public void Init(int id, Sprite sprite,int count) {
            this.id = id;
            imageIcon.sprite = sprite;
            
        }

    }
}