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
        
        public Sprite sprite;
        public string description;

        public StuffSpawnTM spawnTM; // 生成物品(不该这么调)
    }
}