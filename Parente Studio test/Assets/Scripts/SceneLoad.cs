using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

//Loading scene script
public class SceneLoad : MonoBehaviour
{
    //Reference to fill that will gradually increase as game loading progress increases
    [SerializeField]
    private Image _loadingBar;

    //Wait 2 seconds at start of this method and then execute LoadAsyncOperation
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(LoadAsyncOperation());
    }

    //Loads scene in the background and in the same time it fills bar depending on loading progress
    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation mainMenu = SceneManager.LoadSceneAsync(5);
        while (mainMenu.progress < 1)
        {
            _loadingBar.fillAmount = mainMenu.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
