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
        public bool isPick; // 每次重启都要手动取消勾选, 待改 (写个继续游戏?)
        
        public Sprite sprite;
        public string description;
    }
}