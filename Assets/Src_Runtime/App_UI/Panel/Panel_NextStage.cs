using System;
using UnityEngine;
using UnityEngine.UI;

public class panel_NextStage : MonoBehaviour
{
    [SerializeField] Button btn_NextGame;
    public Action OnNextGameHandler;

    [SerializeField] Button btn_QuitGame;
    public Action OnQuitGameHandler;

    public void Ctor()
    {
        btn_NextGame.onClick.AddListener(() =>
        {
            if (OnNextGameHandler != null)
            {
                OnNextGameHandler();
            }
        });

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