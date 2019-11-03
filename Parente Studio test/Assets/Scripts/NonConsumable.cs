using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonConsumable : Item
{
    [SerializeField]
    private TrackerScriptableObject coinCount;
    public override void OnPickup()
    {
        base.OnPickup();
        coinCount.Value++;
    }
    private void Update()
    {
        
    }
}
