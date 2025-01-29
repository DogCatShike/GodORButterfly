using System;
using UnityEngine;

namespace GB
{
    public class MapEntity : MonoBehaviour
    {
        public int stageID;

        public void Ctor()
        {

        }

        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}