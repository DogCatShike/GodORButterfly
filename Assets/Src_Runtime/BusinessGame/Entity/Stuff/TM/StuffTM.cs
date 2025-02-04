using System;
using UnityEngine;

namespace GB
{
    [Serializable]
    public class StuffTM
    {
        public string typeName;
        public int typeID;

        public int spawnStageID;
        public bool isPick;
        
        public Sprite sprite;
        public string description;
    }
}