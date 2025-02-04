using System;
using UnityEngine;

namespace GB
{
    public class InteractionEntity : MonoBehaviour
    {
        public int idSig;
        public int typeID;

        public int stuffTypeID; // 可交互的物品ID

        public int times; // 可交互次数

        public void Ctor()
        {

        }

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