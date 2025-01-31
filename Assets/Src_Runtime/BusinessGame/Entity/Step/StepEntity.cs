using System;
using UnityEngine;

namespace GB
{
    // Step感觉没必要用TM
    
    public class StepEntity : MonoBehaviour
    {
        public int idSig;
        // 感觉用不上
        // public int typeID;

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