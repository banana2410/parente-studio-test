using UnityEngine;
using UnityEngine.UI;

//SCRIPT FOR GETTING INPUT FROM THE PLAYER
public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public Vector2 input;


    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
