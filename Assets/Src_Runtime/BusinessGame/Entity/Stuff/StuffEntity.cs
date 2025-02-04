using System;
using UnityEngine;

namespace GB {
    public class StuffEntity : MonoBehaviour {

        [SerializeField] SpriteRenderer iconRenderer;
        public int idSig;
        public int typeID;

        public int count;
        public bool isPicked;

        public Sprite icon;
        public string description;

        public void Ctor() {
            iconRenderer.sprite = icon;
        }
        
        // 设置位置旋转
        public void TF_Transfrom(Vector3 pos) {
            transform.position = pos;
        }

        public void TF_Rotation(Vector3 v) {
            transform.rotation = Quaternion.Euler(v);
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}