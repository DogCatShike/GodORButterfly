using System;
using UnityEngine;

namespace GB
{
    public class StepEntity : MonoBehaviour
    {
        public int idSig;
        public int typeID; // 0向上, 1向下

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