using System;
using UnityEngine;

namespace GB
{
    public class RoleEntity : MonoBehaviour
    {
        public int idSig;
        public int typeID;

        public void Ctor()
        {

        }

        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}