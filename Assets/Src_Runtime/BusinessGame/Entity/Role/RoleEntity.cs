using System;
using UnityEngine;

namespace GB {
    public class RoleEntity : MonoBehaviour {
        public int idSig;
        public int typeID;

        [SerializeField] Rigidbody2D rb;
        public float moveSpeed;

        [SerializeField] Animator animator;

        // bag
        BagComponent bag;
        public BagComponent Bag => bag;

        public void Ctor() {
            rb = GetComponent<Rigidbody2D>();
            moveSpeed = 5;
            animator = GetComponent<Animator>();

            bag = new BagComponent();
        }

        public void Move(Vector2 dir) {
            var velo = rb.velocity;
            float veloy = velo.y;
            velo.x = dir.x * moveSpeed;
            velo.y = veloy;
            rb.velocity = velo;

            if (dir.x > 0) {
                transform.localScale = new Vector3(1, 1, 1);
            } else if (dir.x < 0) {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            float animMove = Mathf.Abs(dir.x);
            animator.SetFloat("Move", animMove);
        }

        public void StopMove() {
            var velo = rb.velocity;
            velo.x = 0;
            rb.velocity = velo;

            animator.SetFloat("Move", 0);
        }

        public void TearDown() {
            Destroy(gameObject);
        }
    }
}