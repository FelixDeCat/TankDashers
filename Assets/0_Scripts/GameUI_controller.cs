using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tools.Extensions;
using UnityEngine.UI;

public class GameUI_controller : MonoBehaviour
{
    public static GameUI_controller instance;
    [SerializeField] Canvas myCanvas; public Canvas MyCanvas { get => myCanvas; }
    [SerializeField] private GameMenu_UI gameMenu_UI;
    public bool openUI { get; private set; }
    public void Initialize() { gameMenu_UI.Initialize(); }
    public void UI_RefreshMenu() => gameMenu_UI.Refresh();

    public void Set_Opened_UI() { openUI = true; GameManager.instance.Pause(); }
    public void Set_Closed_UI() { openUI = false; GameManager.instance.Play(); }
    public void OpenMenu()
    {
        if (!openUI)
        {
            gameMenu_UI.Open();
            Set_Opened_UI();
        }
        else
        {
            gameMenu_UI.Close();
            Set_Closed_UI();
        }
    }
}
