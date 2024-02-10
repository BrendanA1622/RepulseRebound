using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField]
    private Button menuButton;

    void Start()
    {
        menuButton.onClick.AddListener(BackToMenu);
    }

    private void BackToMenu()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.MainMenu);
    }
}
