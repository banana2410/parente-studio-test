using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Second script of nonimplemented save system
[System.Serializable]
public class Progress : MonoBehaviour
{
    public int coinCountInt;
    public int skullCountInt;
    public int bottleCountInt;

    public TrackerScriptableObject coinCount;
    public TrackerScriptableObject skullCount;
    public TrackerScriptableObject bottleCount;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public Progress(Progress progress)
    {
        coinCountInt = coinCount.Value;
        skullCountInt = skullCount.Value;
        bottleCountInt = bottleCount.Value;
    }
    private void OnEnable()
    {
        SaveSystem.LoadStats();
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            SaveSystem.SaveStats(this);
        }
    }
}
