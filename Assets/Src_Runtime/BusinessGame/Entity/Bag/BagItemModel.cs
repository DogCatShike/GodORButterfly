using System;
using UnityEngine;

namespace GB {

    public class BagItemModel {
        public int id;
        public int typeID;
        public string name;
        public Sprite icon;

        public int count;

        public string description;

        public StuffSpawnTM spawnTM;
    }
}