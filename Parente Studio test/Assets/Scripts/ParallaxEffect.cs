using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float lenght;
    private float startPos;
    [SerializeField] private float _parallaxEffectIntensity;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        cam = Camera.main;
        startPos = transform.position.x;
        lenght = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //ParallaxEffectAction();
    }
    private void LateUpdate()
    {
        ParallaxEffectAction();
    }

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
