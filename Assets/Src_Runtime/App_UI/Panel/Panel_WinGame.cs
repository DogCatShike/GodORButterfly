using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_WinGame : MonoBehaviour
{
    [SerializeField] Button btn_QuitGame;
    public Action OnQuitGameHandler;

    public void Ctor()
    {
        btn_QuitGame.onClick.AddListener(() =>
        {
            if (OnQuitGameHandler != null)
            {
                OnQuitGameHandler();
            }
        });
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