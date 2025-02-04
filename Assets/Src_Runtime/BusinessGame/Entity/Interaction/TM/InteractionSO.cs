using System;
using UnityEngine;

namespace GB
{
    [CreateAssetMenu(fileName = "InteractionSo_", menuName = "GB/So_Interaction_")]
    public class InteractionSO : ScriptableObject
    {
        public InteractionTM tm;
    }
}