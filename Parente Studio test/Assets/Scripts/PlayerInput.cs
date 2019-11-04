using UnityEngine;

//SCRIPT FOR GETTING INPUT FROM THE PLAYER
public class PlayerInput : MonoBehaviour
{
    
    public Vector2 input;

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }
}
