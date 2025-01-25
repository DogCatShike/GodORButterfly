using System;
using UnityEngine;

namespace GB
{
    public class GameContext
    {
        public GameEntity gameEntity;

        //Core
        public AssetsCore assetsCore;
        public TemplateCore templateCore;
        public InputCore inputCore;
        public UIApp uiApp;

        //Repo
        public RoleRepository roleRepository;

        public GameContext()
        {
            gameEntity = new GameEntity();
            
            assetsCore = new AssetsCore();
            templateCore = new TemplateCore();
            inputCore = new InputCore();
            uiApp = new UIApp();

            roleRepository = new RoleRepository();
        }

        public void Inject(Canvas canvas)
        {
            uiApp.Inject(assetsCore, canvas);
        }
    }
}