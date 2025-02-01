using System;
using UnityEngine;

namespace GB {
    public class UIEvent {
        public Action OnStartGameHandle;
        public void Panel_StartGameClick() {
            if (OnStartGameHandle != null) {
                OnStartGameHandle.Invoke();
            }
        }

        public Action OnQuitGameHandle;
        public void Panel_QuitGameClick() {
            if (OnQuitGameHandle != null) {
                OnQuitGameHandle.Invoke();
            }
        }

        public Action OnContinueGameHandle;
        public void Panel_ContinueGameClick() {
            if (OnContinueGameHandle != null) {
                OnContinueGameHandle.Invoke();
            }
        }

        public Action OnBackGameHandle;
        public void Panel_BackGameClick() {
            if (OnBackGameHandle != null) {
                OnBackGameHandle.Invoke();
            }
        }

        public Action<int> OnUseHandle;
        public void Panel_BagElementUse(int id) {
            if (OnUseHandle != null) {
                OnUseHandle.Invoke(id);
            }
        }
    }
}