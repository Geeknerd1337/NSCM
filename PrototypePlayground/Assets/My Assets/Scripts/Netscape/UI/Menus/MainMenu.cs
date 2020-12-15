using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator a;
    private LevelSaveDataController saveController;
    public GameObject optionsMenu;
    public GameObject mainMenu;
    void Start()
    {
        a = GetComponent<Animator>();
        saveController = FindObjectOfType<LevelSaveDataController>();
        optionsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(6);
    }

    public void LoadGame()
    {
        Debug.Log("HELLO");
        saveController.LaunchAutosaveLevel();
    }

    public void StartGame()
    {
        if (!a.GetCurrentAnimatorStateInfo(0).IsName("FadeOut"))
        {
            a.Play("FadeOut");
        }
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void GoBack()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
