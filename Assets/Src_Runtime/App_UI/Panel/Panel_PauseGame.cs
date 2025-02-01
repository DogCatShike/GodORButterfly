using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_PauseGame : MonoBehaviour
{
    [SerializeField] Button btn_ContinueGame;
    public Action OnContinueGameHandler;

    [SerializeField] Button btn_BackGame;
    public Action OnBackGameHandler;

    public void Ctor()
    {
        btn_ContinueGame.onClick.AddListener(() =>
        {
            if (OnContinueGameHandler != null)
            {
                OnContinueGameHandler();
            }
        });

        btn_BackGame.onClick.AddListener(() =>
        {
            if (OnBackGameHandler != null)
            {
                OnBackGameHandler();
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