using System;
using UnityEngine;

namespace GB
{
    [Serializable]
    public class InteractionTM
    {
        public int typeID;
        public string typeName;

        public int spawnStageID;
        public int stuffTypeID; // 可交互的物品ID

        public bool isVictory; // 是否为胜利条件
    }
}