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
        public MapRepository mapRepository;
        public StuffRepository stuffRepository;
        public StepRepository stepRepository;
        public InteractionRepository interactionRepository;
        public StageRepository stageRepository;

        public GameContext()
        {
            gameEntity = new GameEntity();

            assetsCore = new AssetsCore();
            templateCore = new TemplateCore();
            inputCore = new InputCore();
            uiApp = new UIApp();

            roleRepository = new RoleRepository();
            mapRepository = new MapRepository();
            stuffRepository = new StuffRepository();
            stepRepository = new StepRepository();
            interactionRepository = new InteractionRepository();
            stageRepository = new StageRepository();
        }

        public void Inject(Canvas canvas)
        {
            uiApp.Inject(assetsCore, canvas);
        }

        public RoleEntity Get_Role()
        {
            roleRepository.TryGet(gameEntity.ownerID, out RoleEntity role);
            return role;
        }

        public MapEntity Get_Map()
        {
            mapRepository.TryGet(gameEntity.mapID, out MapEntity map);
            return map;
        }

        public StageEntity Get_Stage()
        {
            stageRepository.TryGet(gameEntity.mapID, out StageEntity stage);
            return stage;
        }
    }
}