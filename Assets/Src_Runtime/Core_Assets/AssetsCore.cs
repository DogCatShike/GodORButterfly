using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace GB
{
    public class AssetsCore
    {
        public Dictionary<string, GameObject> entities;
        public AsyncOperationHandle entitiesHandle;

        public Dictionary<string, GameObject> panels;

        public AsyncOperationHandle panelsHandle;

        public AssetsCore()
        {
            entities = new Dictionary<string, GameObject>();
            panels = new Dictionary<string, GameObject>();
        }

        public async Task LoadAll()
        {
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "Entity";
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);

                var all = await handle.Task;
                foreach (var item in all) {
                    entities.Add(item.name, item);
                }

                entitiesHandle = handle;
            }
            
            {
                AssetLabelReference labelReference = new AssetLabelReference();
                labelReference.labelString = "Panel";
                var handle = Addressables.LoadAssetsAsync<GameObject>(labelReference, null);

                var all = await handle.Task;

                foreach (var item in all) {
                    panels.Add(item.name, item);
                }

                panelsHandle = handle;
            }
        }

        public void UnLoadAll()
        {
            if(entitiesHandle.IsValid())
            {
                Addressables.Release(entitiesHandle);
            }

            if(panelsHandle.IsValid())
            {
                Addressables.Release(panelsHandle);
            }
        }

        //Entity
        public GameObject Entity_GetRole()
        {
            entities.TryGetValue("Entity_Role", out GameObject entity);
            return entity;
        }

        public GameObject Entity_GetMap(int stageID)
        {
            entities.TryGetValue("Entity_Map_" + stageID, out GameObject entity);
            return entity;
        }

        public GameObject Entity_GetStuff(int typeID)
        {
            entities.TryGetValue("Entity_Stuff_" + typeID, out GameObject entity);
            return entity;
        }

        public GameObject Entity_GetStep()
        {
            entities.TryGetValue("Entity_Step", out GameObject entity);
            return entity;
        }

        //Panel
        public GameObject Panel_GetStartGame()
        {
            panels.TryGetValue("Panel_StartGame", out GameObject panel);
            return panel;
        }
        public GameObject Panel_GetBag()
        {
            panels.TryGetValue("Panel_Bag", out GameObject panel);
            return panel;
        }
    }
}