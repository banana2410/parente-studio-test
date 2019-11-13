using UnityEngine.EventSystems;
using UnityEngine;


//Button script that isn't implemented to help determine if button is pressed or not pressed
public class ButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private void Start()
    {
        
    }
    // Define a property so that other classes can know whether the button is pressed
    public bool IsPressed
    {
        get;
        private set;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        IsPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsPressed = false;
    }

}