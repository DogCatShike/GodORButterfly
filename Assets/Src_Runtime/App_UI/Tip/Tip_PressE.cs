using System;
using UnityEngine;
using UnityEngine.UI;

namespace GB
{
    public class Tip_PressE : MonoBehaviour
    {
        public void Ctor()
        {
            
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void TearDown()
        {
            Destroy(gameObject);
        }
    }
}