using System;
using UnityEngine;

namespace GB
{
    public class CameraEntity : MonoBehaviour
    {
        public void FollowTarget(Transform target, GameObject bg, float dt)
        {
            Vector3 pos = transform.position;
            pos.x = target.position.x;

            pos.x = Mathf.Clamp(pos.x, 0, 10); // 暂定x最大10

            transform.position = pos;
            bg.transform.position = pos;
        }
    }
}