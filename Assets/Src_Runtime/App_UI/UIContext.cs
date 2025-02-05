using System;
using UnityEngine;

namespace GB {
    public class UIContext {
        public UIEvent uiEvent;

        //UI
        public Panel_StartGame panel_StartGame;
        public Panel_PauseGame panel_PauseGame;
        public Panel_CantUse panel_CantUse;
        public panel_NextStage panel_NextStage;
        public Panel_WinGame panel_WinGame;

        public Panel_Bag panel_Bag;

        public Tip_PressE tip_PressE;
        public Tip_UseStuff tip_UseStuff;

        //core
        public AssetsCore assetsCore;
        public Canvas canvas;

        public UIContext() {
            uiEvent = new UIEvent();
        }

        public void Inject(AssetsCore assetsCore, Canvas canvas) {
            this.assetsCore = assetsCore;
            this.canvas = canvas;
        }
    }
}