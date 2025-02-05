using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB
{
    public class StageEntity : MonoBehaviour
    {
        public int stageID;

        public Dictionary<int, bool> stuffIsPick; // typeID, isPicked
        public Dictionary<int, int> interactionTimes; // typeID, times

        public void Ctor()
        {
            stuffIsPick = new Dictionary<int, bool>();
            interactionTimes = new Dictionary<int, int>();
        }

        public void AddStuff(StuffEntity stuff)
        {
            stuffIsPick.Add(stuff.typeID, stuff.isPicked);
            Debug.Log(stageID + " AddStuff: " + stuff.typeID + " " + stuff.isPicked);
        }

        public void AddInteraction(InteractionEntity interaction)
        {
            interactionTimes.Add(interaction.typeID, interaction.times);
            Debug.Log(stageID + " AddInteraction: " + interaction.typeID + " " + interaction.times);
        }

        public void RemoveStuff(StuffEntity stuff)
        {
            stuffIsPick.Remove(stuff.typeID);
            Debug.Log(stageID + " RemoveStuff: " + stuff.typeID);
        }

        public void RemoveInteraction(InteractionEntity interaction)
        {
            interactionTimes.Remove(interaction.typeID);
            Debug.Log(stageID + " RemoveInteraction: " + interaction.typeID);
        }

        public bool TryGetStuff(int typeID, out bool isPicked)
        {
            bool hasStuff = stuffIsPick.ContainsKey(typeID);

            if (hasStuff)
            {
                stuffIsPick.TryGetValue(typeID, out isPicked);
                Debug.Log(stageID + " TryGetStuff: " + typeID + " " + isPicked);
                return stuffIsPick.TryGetValue(typeID, out isPicked);
            }
            isPicked = false;
            Debug.Log("DontHasStuff: " + typeID);
            return false;
        }

        public bool TryGetInteraction(int typeID, out int times)
        {
            bool hasInteraction = interactionTimes.ContainsKey(typeID);

            if (hasInteraction)
            {
                interactionTimes.TryGetValue(typeID, out times);
                Debug.Log(stageID + " TryGetInteraction: " + typeID + " " + times);
                return interactionTimes.TryGetValue(typeID, out times);
            }
            times = 0;
            Debug.Log("DontHasInteraction: " + typeID);
            return false;
        }

        public void Clear()
        {
            stuffIsPick.Clear();
            interactionTimes.Clear();
        }

        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}