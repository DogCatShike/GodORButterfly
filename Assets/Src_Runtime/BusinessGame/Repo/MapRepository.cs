using System;
using System.Collections.Generic;
using UnityEngine;

namespace GB
{
    public class MapRepository
    {
        Dictionary<int, MapEntity> all;

        MapEntity[] temArray;

        public MapRepository()
        {
            all = new Dictionary<int, MapEntity>();
            temArray = new MapEntity[100];
        }

        public void Add(MapEntity entity)
        {
            all.Add(entity.stageID, entity);
        }

        public void Remove(MapEntity entity)
        {
            all.Remove(entity.stageID);
        }

        public int TakeAll(out MapEntity[] array)
        {
            if (all.Count > temArray.Length)
            {
                temArray = new MapEntity[all.Count * 2];
            }
            all.Values.CopyTo(temArray, 0);
            array = temArray;
            return all.Count;
        }

        public bool TryGet(int idSig, out MapEntity entity)
        {
            return all.TryGetValue(idSig, out entity);
        }

        public void Clear()
        {
            all.Clear();
        }
    }
}