using System;
using UnityEngine;

namespace GB
{
    public class UIApp
    {
        UIContext ctx;
        public UIEvent events;

        public UIApp()
        {
            ctx = new UIContext();
        }

        public UIEvent GetEvents()
        {
            return ctx.uiEvent;
        }

        public void SetEvents(UIEvent value)
        {
            ctx.uiEvent = value;
        }

        public void Inject(AssetsCore assetsCore, Canvas canvas)
        {
            ctx.Inject(assetsCore, canvas);
        }

        public void Panel_StartGame_Open()
        {
            Panel_StartGame panel = ctx.panel_StartGame;

            if (panel == null)
            {
                GameObject go = ctx.assetsCore.Panel_GetStartGame();
                if (!go)
                {
                    Debug.LogError("Panel_StartGame not found");
                    return;
                }

                panel = GameObject.Instantiate(go, ctx.canvas.transform).GetComponent<Panel_StartGame>();
                panel.Ctor();

                panel.OnStartGameHandler += () =>
                {
                    ctx.uiEvent.Panel_StartGameClick();
                };
                panel.OnQuitGameHandler += () =>
                {
                    ctx.uiEvent.Panel_QuitGameClick();
                };
            }

            ctx.panel_StartGame = panel;
        }

        public void Panel_StartGame_Close()
        {
            Panel_StartGame panel = ctx.panel_StartGame;

            if (panel == null)
            {
                return;
            }
            panel.TearDown();
        }
    }
}