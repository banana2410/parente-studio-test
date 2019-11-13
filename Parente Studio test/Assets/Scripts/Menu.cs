using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

//Menu script that sits on canvas and manages open closing menus and scenes
public class Menu : MonoBehaviour
{
    public TrackerScriptableObject coins;
    public TrackerScriptableObject lives;
    public TrackerScriptableObject bottles;
    public GameObject BuyCoinsMenu;
    public GameObject PauseMenu;
    public GameObject SettingsMenu;
    public GameObject ExitMenu;
    public GameObject GameHUD;
    public GameObject LevelSelectMenu;
    public GameObject MainMenu;
    public GameObject GameOverScreen;

    private void Start()
    {
        
    }

    public void BuyCoinsMenuOpen()
    {
        BuyCoinsMenu.SetActive(!BuyCoinsMenu.activeSelf);
        if(GameHUD != null)
        {
            GameHUD.SetActive(!GameHUD.activeSelf);
        }
        if(PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }
    }

    public void BuyFirstStack()
    {
        coins.Value += 200;
    }
    public void BuySecondStack()
    {
        coins.Value += 1000;
    }
    public void BuyBottles()
    {
        bottles.Value += 5;
    }
    public void BuyLives()
    {
        lives.Value += 5;
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(2);
    }
    public void StartLevel3()
    {
        SceneManager.LoadScene(3);
    }
    public void StartLevel4()
    {
        SceneManager.LoadScene(4);
    }

    public void ShowHideHud()
    {
        GameHUD.SetActive(!GameHUD.activeSelf);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(5);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OpenClosePauseMenu()
    {
        Debug.Log("Opened");
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
    public void LevelSelect()
    {
        LevelSelectMenu.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void BackToMainMenu()
    {
        LevelSelectMenu.SetActive(false);
        MainMenu.SetActive(true);
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
