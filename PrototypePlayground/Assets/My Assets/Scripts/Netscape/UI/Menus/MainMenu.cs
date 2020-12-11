using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator a;
    public GameObject optionsMenu;
    public GameObject mainMenu;
    void Start()
    {
        a = GetComponent<Animator>();
        optionsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
