using System;
using UnityEngine;

namespace GB {
    public class GameEntity {
        public float restFixTime;

        public GameState state;

        public int ownerID;
        public int mapID;
        public int stuffID;
        public int stepID; // 没必要吧，这种唯一的东西
        public int itemIDRecord;

        // 临时数据 
        public StuffEntity currentStuff;
        public StepEntity currentStep;
        public InteractionEntity currentInteraction;

        public int currentStuffID;


        public GameEntity() {
            restFixTime = 0;

            state = GameState.Login;

            ownerID = 0;
            mapID = 0;
            stuffID = 0;
            stepID = 0;
            itemIDRecord = 0;

            currentStuff = null;
            currentStep = null;
            currentInteraction = null;

            currentStuffID = -1;
        }
    }
}