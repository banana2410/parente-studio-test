using UnityEngine;

//SCRIPT FOR NONCONSUMABLE ITEMS(COINS)
public class NonConsumable : Item
{
    //REFERENCE TO DATA CONTAINER THAT CONTAINS COIN COUNT
    [SerializeField]
    private TrackerScriptableObject coinCount;
    public override void OnPickup()
    {
        base.OnPickup();
        coinCount.Value++;
    }
}
