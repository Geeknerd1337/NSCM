using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPause : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject pauseMenuUI;
    [SerializeField]
    private SettingsMenu settings;
    private float fov;
    public float FOV
    {
        get
        {
            return fov;
        }
    }
    private void Start()
    {
        if (settings != null)
        {
            fov = settings.FOV;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (GamePaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Resume();
        SceneManager.LoadScene(0);
    }

    public void UpdateFOV()
    {
        if (settings != null)
        {
            fov = settings.FOV;
        }
    }

}
