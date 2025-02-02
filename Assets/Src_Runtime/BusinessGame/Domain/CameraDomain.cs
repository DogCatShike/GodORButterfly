using System;
using UnityEngine;

namespace GB
{
    public static class CameraDomain
    {
        public static void FollowTarget(Transform target, GameObject bg, float dt)
        {
            GameObject go = Camera.main.gameObject;
            CameraEntity camera = go.GetComponent<CameraEntity>();

            camera.FollowTarget(target, bg, dt);
        }
    }
}