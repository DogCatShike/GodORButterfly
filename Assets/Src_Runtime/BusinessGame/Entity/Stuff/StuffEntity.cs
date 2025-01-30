using System;
using UnityEngine;

namespace GB
{
    public class StuffEntity : MonoBehaviour
    {
        public int idSig;
        public int typeID;

        public void Ctor()
        {

        }

        // 设置位置旋转
        public void TF_Transfrom(Vector3 pos)
        {
            transform.position = pos;
        }

        public void TF_Rotation(Vector3 v)
        {
            transform.rotation = Quaternion.Euler(v);
        }

        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}