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

        public Dictionary<int, StepTM> steps;
        public AsyncOperationHandle stepHandle;

        public Dictionary<int, InteractionTM> interactions;
        public AsyncOperationHandle interactionHandle;

        public TemplateCore()
        {
            stages = new Dictionary<int, StageTM>();
            stuffs = new Dictionary<int, StuffTM>();
            steps = new Dictionary<int, StepTM>();
            interactions = new Dictionary<int, InteractionTM>();
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
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "So_Step";
                var handle = Addressables.LoadAssetsAsync<StepSO>(labelReference, null);
                var all = await handle.Task;

                foreach (var so in all)
                {
                    var tm = so.tm;
                    steps.Add(tm.typeID, tm);
                }

                stepHandle = handle;
            }
            {
                AssetLabelReference labelReference = new AssetLabelReference();

                labelReference.labelString = "So_Interaction";
                var handle = Addressables.LoadAssetsAsync<InteractionSO>(labelReference, null);
                var all = await handle.Task;

                foreach (var so in all)
                {
                    var tm = so.tm;
                    interactions.Add(tm.typeID, tm);
                }

                interactionHandle = handle;
            }
        }

        public bool TryGetStage(int stageID, out StageTM stage)
        {
            return stages.TryGetValue(stageID, out stage);
        }

        public bool TryGetStuff(int typeID, out StuffTM stuff)
        {
            return stuffs.TryGetValue(typeID, out stuff);
        }

        public bool TryGetStep(int typeID, out StepTM step)
        {
            return steps.TryGetValue(typeID, out step);
        }

        public bool TryGetInteraction(int typeID, out InteractionTM interaction)
        {
            return interactions.TryGetValue(typeID, out interaction);
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