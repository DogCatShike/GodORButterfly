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

        public void Panel_PauseGame_Open() {
            Panel_PauseGame panel = ctx.panel_PauseGame;

            if (panel == null) {
                GameObject go = ctx.assetsCore.Panel_GetPauseGame();
                if (!go) {
                    Debug.LogError("Panel_PauseGame not found");
                    return;
                }

                panel = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Panel_PauseGame>();
                panel.Ctor();

                panel.OnContinueGameHandler += () => {
                    ctx.uiEvent.Panel_ContinueGameClick();
                };
                panel.OnBackGameHandler += () => {
                    ctx.uiEvent.Panel_BackGameClick();
                };
            }

            ctx.panel_PauseGame = panel;
        }

        public void Panel_PauseGame_Close() {
            Panel_PauseGame panel = ctx.panel_PauseGame;

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

        public void Bag_SetTextSprite(string content, Sprite sprite) {
            Panel_Bag bag = ctx.panel_Bag;
            bag?.Set_TextSprite(content, sprite);
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

        public void Tip_PressE_Open(RoleEntity role) {
            Tip_PressE tip = ctx.tip_PressE;

            if (tip == null) {
                GameObject go = ctx.assetsCore.Tip_GetPressE();
                if (!go) {
                    Debug.LogError("Tip_PressE not found");
                    return;
                }

                tip = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Tip_PressE>();
                tip.Ctor();

                Vector2 pos = role.transform.localPosition;
                pos.y = -30;
                tip.transform.localPosition = pos;
            }

            ctx.tip_PressE = tip;
        }

        public bool isPressEOpened() {
            Tip_PressE tip = ctx.tip_PressE;
            return tip != null;
        }

        public void Tip_PressE_Close() {
            Tip_PressE tip = ctx.tip_PressE;

            if (tip == null) {
                return;
            }
            tip.TearDown();
        }

        public void Tip_UseStuff_Open(RoleEntity role) {
            Tip_UseStuff tip = ctx.tip_UseStuff;

            if (tip == null) {
                GameObject go = ctx.assetsCore.Tip_GetUseStuff();
                if (!go) {
                    Debug.LogError("Tip_UseStuff not found");
                    return;
                }

                tip = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Tip_UseStuff>();
                tip.Ctor();

                Vector2 pos = role.transform.localPosition;
                pos.y = -30;
                tip.transform.localPosition = pos;
            }

            ctx.tip_UseStuff = tip;
        }

        public bool isUseStuffOpened() {
            Tip_UseStuff tip = ctx.tip_UseStuff;
            return tip != null;
        }

        public void Tip_UseStuff_Close() {
            Tip_UseStuff tip = ctx.tip_UseStuff;

            if (tip == null) {
                return;
            }
            tip.TearDown();
        }
    }
}