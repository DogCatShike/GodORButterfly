using System;
using UnityEngine;

namespace GB {
    public class InputCore {
        public InputController_Player input_Role;
        public Vector2 moveAxis;

        public bool isKeyDownEsc;
        public bool isKeyDownTab;
        public bool isKeyDownE;
        public bool isKeyEnter;

        public InputCore() {
            input_Role = new InputController_Player();
            input_Role.Enable();
        }

        public void Disable() {
            input_Role.Disable();
        }

        public void Process() {
            var Player = input_Role.Player;

            {
                // kbx什么意思 键盘
                float kbxLeft = Player.MoveLeft.ReadValue<float>();
                float kbxRight = Player.MoveRight.ReadValue<float>();

                Vector2 axis = new Vector2(kbxRight - kbxLeft, 0);
                moveAxis = axis;
            }
            // esc键
            {
                if (Player.PressEsc.triggered) {
                    isKeyDownEsc = true;
                } else {
                    isKeyDownEsc = false;
                }
            }
            // tab键
            {
                if (Player.PressTab.triggered) {
                    isKeyDownTab = true;
                } else {
                    isKeyDownTab = false;
                }
            }
            // e键
            {
                if (Player.PressE.triggered) {
                    isKeyDownE = true;
                } else {
                    isKeyDownE = false;
                }
            }
            // Enter键
            {
                if (Player.PressEnter.triggered) {
                    isKeyEnter = true;
                } else {
                    isKeyEnter = false;
                }
            }
        }
    }
}