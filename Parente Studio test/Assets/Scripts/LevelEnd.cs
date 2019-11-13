using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gets called when player finishes level
public class LevelEnd : MonoBehaviour
{
    public GameObject Gui;
    public GameObject LevelFinished;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Time.timeScale = 0f;
            LevelFinished.SetActive(true);
            Gui.SetActive(!Gui.activeSelf);
        }
    }
}
