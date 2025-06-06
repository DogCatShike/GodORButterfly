using System;
using UnityEngine;

namespace GB
{
    [Serializable]
    public class StageTM
    {
        public int stageID;
        public StuffSpawnTM[] stuffSpawns;
        public InteractionSpawnTM[] interactionSpawns;
        public StepSpawnTM stepSpawn;
    }
}