using System;
using UnityEngine;

namespace GB
{
    public class GameEntity
    {
        public float restFixTime;

        public GameState state;

        public int ownerID;
        public int mapID;
        public int stuffID;

        public GameEntity()
        {
            restFixTime = 0;

            state = GameState.Login;

            ownerID = 0;
            mapID = 0;
            stuffID = 0;
        }
    }
}