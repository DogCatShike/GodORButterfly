using System;
using UnityEngine;

namespace GB
{
    [CreateAssetMenu(fileName = "StageSo_", menuName = "GB/So_Stage_")]
    public class StageSO : ScriptableObject
    {
        public StageTM tm;
    }
}