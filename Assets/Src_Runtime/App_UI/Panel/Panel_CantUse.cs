using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_CantUse : MonoBehaviour
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