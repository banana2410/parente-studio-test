using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform rayStartPos;
    [SerializeField] private LayerMask whatIsGround;
    private Vector3 leftRotation;
    [SerializeField] private float _speed;


    public bool goingLeft;

    private void Awake()
    {
        leftRotation = new Vector3(0f, -90f, 0);
    }
    private void Start()
    {
        goingLeft = true;
    }
    private void Update()
    {
        if(goingLeft)
        {
            MoveLeft();
        }
        else
        {
            MoveRight();
        }
        if (!GroundDetection())
        {
            goingLeft = !goingLeft;
            Turn();
        }
    }

    private bool GroundDetection()
    {
        return Physics.Raycast(rayStartPos.transform.position, Vector2.down, 1f, whatIsGround);
    }

    public void Turn()
    {
        float currRotationY = gameObject.transform.rotation.y;
        if (currRotationY < 0f)
        {
            gameObject.transform.rotation = Quaternion.Euler(-leftRotation);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(leftRotation);
        }
    }

    public void MoveRight()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime * _speed, Space.World);
    }
    public void MoveLeft()
    {
        gameObject.transform.Translate(Vector2.left * Time.deltaTime * _speed, Space.World);
    }

}
