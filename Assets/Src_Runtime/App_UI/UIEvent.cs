using System;
using UnityEngine;

namespace GB
{
    public class UIEvent
    {
        public Action OnStartGameHandle;
        public void Panel_StartGameClick()
        {
            if(OnStartGameHandle != null)
            {
                OnStartGameHandle.Invoke();
            }
        }

        public Action OnQuitGameHandle;
        public void Panel_QuitGameClick()
        {
            if(OnQuitGameHandle != null)
            {
                OnQuitGameHandle.Invoke();
            }
        }
    }
}