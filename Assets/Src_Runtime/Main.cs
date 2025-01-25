using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GB
{
    public class Main : MonoBehaviour
    {
        GameContext ctx;
        [SerializeField] Canvas screenCanvas;

        bool isTearDown = false;
        bool isInit = false;

        void Awake()
        {
            // Init
            ctx = new GameContext();
            Canvas canvas = screenCanvas.GetComponent<Canvas>();

            ctx.Inject(canvas);

            //Binding
            Binding();

            Action action = async () => {

                await ctx.assetsCore.LoadAll();
                //TM资源加载
                // await ctx.templateCore.LoadAll();

                isInit = true;

                LoginBusiness.Enter(ctx);
            };
            action.Invoke();
        }

        void Binding()
        {
            var events = ctx.uiApp.GetEvents();
            var game = ctx.gameEntity;

            events.OnStartGameHandle += () => {
                ctx.uiApp.Panel_StartGame_Close();
                Debug.Log("Start Game");
                GameBusiness.Enter(ctx);
            };

            events.OnQuitGameHandle += () => {
                Application.Quit();
                Debug.Log("Quit Game");
            };
        }

        void Update()
        {
            
        }
    }
}
