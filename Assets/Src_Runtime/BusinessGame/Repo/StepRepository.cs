using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB
{
    public class StepRepository
    {
        Dictionary<int, StepEntity> all;

        StepEntity[] temArray;

        public StepRepository()
        {
            all = new Dictionary<int, StepEntity>();
            temArray = new StepEntity[100];
        }

        public void Add(StepEntity entity)
        {
            all.Add(entity.idSig, entity);
        }

        public void Remove(StepEntity entity)
        {
            all.Remove(entity.idSig);
        }

        public int TakeAll(out StepEntity[] array)
        {
            if (all.Count > temArray.Length)
            {
                temArray = new StepEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;
            return all.Count;
        }

        public bool TryGet(int idSig, out StepEntity entity)
        {
            return all.TryGetValue(idSig, out entity);
        }

        public void Clear()
        {
            all.Clear();
        }
    }
}