using UnityEngine;

//SCRIPT THAT IS BASE CLASS FOR ALL PICKUPABLE ITEMS IN GAME
public abstract class Item : MonoBehaviour
{
    //On collision with player, object deactivates itself and calls OnPickup method

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPickup();
        }
    }



    //Method that is called when player collides with pickupable object
    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

}
