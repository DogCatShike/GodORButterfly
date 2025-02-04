using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB
{
    public class StageRepository
    {
        Dictionary<int, StageEntity> all;

        StageEntity[] temArray;

        public StageRepository()
        {
            all = new Dictionary<int, StageEntity>();
            temArray = new StageEntity[100];
        }

        public void Add(StageEntity entity)
        {
            all.Add(entity.stageID, entity);
        }

        public void Remove(StageEntity entity)
        {
            all.Remove(entity.stageID);
        }

        public int TakeAll(out StageEntity[] array)
        {
            if (all.Count > temArray.Length)
            {
                temArray = new StageEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;
            return all.Count;
        }

        public bool TryGet(int stageID, out StageEntity entity)
        {
            return all.TryGetValue(stageID, out entity);
        }

        public void Clear()
        {
            all.Clear();
        }
    }
}