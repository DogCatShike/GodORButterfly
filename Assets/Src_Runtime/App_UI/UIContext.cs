using System;
using UnityEngine;

namespace GB {
    public class UIContext {
        public UIEvent uiEvent;

        //panel
        public Panel_StartGame panel_StartGame;
        public Panel_PauseGame panel_PauseGame;

        public Panel_Bag panel_Bag;

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