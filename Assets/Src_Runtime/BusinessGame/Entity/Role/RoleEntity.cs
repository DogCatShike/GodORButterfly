using System;
using UnityEngine;

namespace GB
{
    public class RoleEntity : MonoBehaviour
    {
        public int idSig;
        public int typeID;

        [SerializeField] Rigidbody2D rb;
        public float moveSpeed;

        public void Ctor()
        {
            rb = GetComponent<Rigidbody2D>();
            moveSpeed = 5;
        }

        public void Move(Vector2 dir)
        {
            var velo = rb.velocity;
            float veloy = velo.y;
            velo.x = dir.x * moveSpeed;
            velo.y = veloy;
            rb.velocity = velo;

            if (dir.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (dir.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        public void StopMove()
        {
            var velo = rb.velocity;
            velo.x = 0;
            rb.velocity = velo;
        }

        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}