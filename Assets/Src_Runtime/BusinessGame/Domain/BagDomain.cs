using System;
using System.Collections;
using UnityEngine;


namespace GB {
    public class BagDomain {

        public static void Toogle(GameContext ctx, BagComponent bag) {
            var ui = ctx.uiApp;
            if (ui.Bag_IsOpened()) {
                Debug.Log("Bag is opened, closing it");
                ui.Bag_Close();
            } else {
                Debug.Log("Bag is closed, opening iddddddddddddddt");
                Open(ctx);
            }
        }

        public static void Open(GameContext ctx) {
            var ui = ctx.uiApp;
            ui.Bag_Open(10);
        }
    }
}