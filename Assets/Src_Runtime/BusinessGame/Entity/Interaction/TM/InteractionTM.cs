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
    }
}