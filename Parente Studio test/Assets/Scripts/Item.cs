using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPickup();
        }
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

}
