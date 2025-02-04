using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB
{
    public class InteractionRepository
    {
        Dictionary<int, InteractionEntity> all;

        InteractionEntity[] temArray;

        public InteractionRepository()
        {
            all = new Dictionary<int, InteractionEntity>();
            temArray = new InteractionEntity[100];
        }

        public void Add(InteractionEntity entity)
        {
            all.Add(entity.idSig, entity);
        }

        public void Remove(InteractionEntity entity)
        {
            all.Remove(entity.idSig);
        }

        public int TakeAll(out InteractionEntity[] array)
        {
            if (all.Count > temArray.Length)
            {
                temArray = new InteractionEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;
            return all.Count;
        }

        public bool TryGet(int idSig, out InteractionEntity entity)
        {
            return all.TryGetValue(idSig, out entity);
        }

        public void Clear()
        {
            all.Clear();
        }
    }
}