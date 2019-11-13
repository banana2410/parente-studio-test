using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that gets called whenever player pickups collectibles
public class PlayerPickup : MonoBehaviour
{
    //Events that gets called when certain object is picked up, subscribing other methods to this so according methods get called too
    public delegate void SkullPickupDelegate();
    public static event SkullPickupDelegate OnSkullPickup;

    public delegate void CoinPickupDelegate();
    public static event CoinPickupDelegate OnCoinPickup;


    //Gets called when player enters object collider
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Skull")
        {
            OnSkullPickup();
        }
        if(other.tag == "Coin")
        {
            OnCoinPickup();
        }
    }
}
