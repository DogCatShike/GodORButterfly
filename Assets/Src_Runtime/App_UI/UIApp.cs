using System;
using UnityEngine;

namespace GB {
    public class UIApp {
        UIContext ctx;
        public UIEvent events;

        public UIApp() {
            ctx = new UIContext();
        }

        public UIEvent GetEvents() {
            return ctx.uiEvent;
        }

        public void SetEvents(UIEvent value) {
            ctx.uiEvent = value;
        }

        public void Inject(AssetsCore assetsCore, Canvas canvas) {
            ctx.Inject(assetsCore, canvas);
        }

        public void Panel_StartGame_Open() {
            Panel_StartGame panel = ctx.panel_StartGame;

            if (panel == null) {
                GameObject go = ctx.assetsCore.Panel_GetStartGame();
                if (!go) {
                    Debug.LogError("Panel_StartGame not found");
                    return;
                }

                panel = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Panel_StartGame>();
                panel.Ctor();

                panel.OnStartGameHandler += () => {
                    ctx.uiEvent.Panel_StartGameClick();
                };
                panel.OnQuitGameHandler += () => {
                    ctx.uiEvent.Panel_QuitGameClick();
                };
            }

            ctx.panel_StartGame = panel;
        }

        public void Panel_StartGame_Close() {
            Panel_StartGame panel = ctx.panel_StartGame;

            if (panel == null) {
                return;
            }
            panel.TearDown();
        }

        #region  Bag
        public void Bag_Open(int maxSlot) {
            Panel_Bag panel = ctx.panel_Bag;
            if (panel == null) {
                GameObject go = ctx.assetsCore.Panel_GetBag();
                if (!go) {
                    Debug.LogError("Panel_Bag not found");
                    return;
                }

                panel = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Panel_Bag>();
                panel.Ctor();

                panel.OnUseHandler += (id) => {
                    ctx.uiEvent.Panel_BagElementUse(id);
                };
            }
            panel.Init(maxSlot);
            ctx.panel_Bag = panel;
        }

        public bool Bag_IsOpened() {
            Panel_Bag bag = ctx.panel_Bag;
            return bag != null;
        }

        public void Bag_Close() {
            Panel_Bag bag = ctx.panel_Bag;
            bag?.Close();
            ctx.panel_Bag = null;
        }
        public void Bag_Add(int id, Sprite icon, int count) {
            Panel_Bag bag = ctx.panel_Bag;
            bag?.Add(id, icon, count);
        }

        #endregion
    }
}