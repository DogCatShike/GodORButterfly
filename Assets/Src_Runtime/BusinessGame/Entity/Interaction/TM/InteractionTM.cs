using System;
using UnityEngine;

namespace GB
{
    [Serializable]
    public class InteractionTM
    {
        public int typeID;

        public int spawnStageID;
        public int stuffTypeID; // 可交互的物品ID

        public int times; // 可交互次数
    }
}