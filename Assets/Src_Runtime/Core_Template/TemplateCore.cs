using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace GB
{
    public class TemplateCore
    {
        public Dictionary<int, StageTM> stages;
        public AsyncOperationHandle stageHandle;

        public Dictionary<int, StuffTM> stuffs;
        public AsyncOperationHandle stuffHandle;

        public TemplateCore()
        {
            stages = new Dictionary<int, StageTM>();
            stuffs = new Dictionary<int, StuffTM>();
        }

        public async Task LoadAll()
        {
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "So_Stage";
                var handle = Addressables.LoadAssetsAsync<StageSO>(labelReference, null);
                var all = await handle.Task;

                foreach (var so in all)
                {
                    var tm = so.tm;
                    stages.Add(tm.stageID, tm);
                }

                stageHandle = handle;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "So_Stuff";
                var handle = Addressables.LoadAssetsAsync<StuffSO>(labelReference, null);
                var all = await handle.Task;

                foreach (var so in all)
                {
                    var tm = so.tm;
                    stuffs.Add(tm.typeID, tm);
                }

                stuffHandle = handle;
            }
        }

        public bool TryGetStage(int stageID, out StageTM stage)
        {
            return stages.TryGetValue(stageID, out stage);
        }

        public void UnLoadAll()
        {
            if (stageHandle.IsValid())
            {
                Addressables.Release(stageHandle);
            }
        }
    }
}