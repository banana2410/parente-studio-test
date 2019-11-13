using System;
using UnityEngine;

//Collectables tracker
public class CollectablesTracker : MonoBehaviour
{
    private int _coinCount;
    private int _trophyCount;

    void OnCoinPickup()
    {
        _coinCount++;
    }
}
