using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public GameObject ExitMenu;
    public GameObject GameHUD;


    void Start()
    {
        
    }

    public void ShowHideHud()
    {
        GameHUD.SetActive(!GameHUD.activeSelf);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OpenClosePauseMenu()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        
        if(PauseMenu.activeSelf)
        {
            ShowHideHud();
            Time.timeScale = 0f;
        }
        else
        {
            ShowHideHud();
            Time.timeScale = 1f;
        }
    }

    public void CloseSettingsMenu()
    {
        SettingsMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
