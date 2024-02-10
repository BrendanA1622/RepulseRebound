using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    [SerializeField]
    private GameObject pauseCanvas;
    [SerializeField]
    private GameObject gameCanvas;


    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Customize,
        Settings,
        DropperGame,
        BlippyMode
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
        Time.timeScale = 1f;
    }

    public void LoadSettings()
    {
        SceneManager.LoadScene(Scene.Settings.ToString());
    }

    public void LoadCustomize()
    {
        SceneManager.LoadScene(Scene.Customize.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.DropperGame.ToString());
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadBlippyMode()
    {
        SceneManager.LoadScene(Scene.BlippyMode.ToString());
    }


    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void disablePauseCanvas()
    {
        pauseCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        Time.timeScale = 1f;
    }

    public void openPauseCanvas()
    {
        pauseCanvas.SetActive(true);
        gameCanvas.SetActive(false);
        Time.timeScale = 0f;
    }
}
