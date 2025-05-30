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

        public Action OnNextGameHandle;
        public void Panel_NextGameClick() {
            if (OnNextGameHandle != null) {
                OnNextGameHandle.Invoke();
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