using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    //Lenght of the sprite
    private float lenght;

    //Start pos of the sprite
    private float startPos;

    //Speed of sprite movement based on camera pos
    [SerializeField] private float _parallaxEffectIntensity;

    //Main cam
    private Camera cam;

    //References
    private void Awake()
    {
        cam = Camera.main;
        startPos = transform.position.x;
        lenght = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }


    private void FixedUpdate()
    {
        ParallaxEffectAction();
    }

    //If sprite is no longer visible, reposition it in camera movement direction to get the 2.5D effect and infinite background
    public void ParallaxEffectAction()
    {
        float tempPos = cam.transform.position.x * (1 - _parallaxEffectIntensity);
        float distance = cam.transform.position.x * _parallaxEffectIntensity;

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
        if(tempPos>startPos+lenght)
        {
            startPos += lenght;
        }
        else if (tempPos < startPos - lenght)
        {
            startPos -= lenght;
        }
    }
}
