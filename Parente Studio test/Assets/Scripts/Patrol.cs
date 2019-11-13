using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script that provides patrol behaviour
public class Patrol : MonoBehaviour
{
    private MouseEnemy _mouseEnemy;

    //Starting point of ground detection ray
    [SerializeField] private Transform rayStartPos;

    //Helps determine enemy to know what to target as a ground
    [SerializeField] private LayerMask whatIsGround;

    //Rotation vector3 so enemy can turn correctly based on direction of movement
    private Vector3 leftRotation;

    //Enemy movement speed
    public float Speed;

    //Is enemy going left?
    public bool goingLeft;

    //References
    private void Awake()
    {
        _mouseEnemy = gameObject.GetComponent<MouseEnemy>();
        leftRotation = new Vector3(0f, -90f, 0);
    }

    private void Start()
    {
        goingLeft = true;
    }

    private void Update()
    {
        PatrolBehaviour();
    }

    //Returns true if raycast detects ground, it starts at rayStartPos
    private bool GroundDetection()
    {
        return Physics.Raycast(rayStartPos.transform.position, Vector2.down, 1f, whatIsGround);
    }

    //Rotate enemy by 90 degrees and changes it direction of movement
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

    //Patrol action, checks if player isn't dead and if it gets to the end of the platform and no longer detects ground, it turns around
    public void PatrolBehaviour()
    {
        if (!_mouseEnemy.isDead)
        {
            if (goingLeft)
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

    }

    //Basic movement functions
    #region Move
    public void MoveRight()
    {
        gameObject.transform.Translate(Vector2.right * Time.deltaTime * Speed, Space.World);
    }
    public void MoveLeft()
    {
        gameObject.transform.Translate(Vector2.left * Time.deltaTime * Speed, Space.World);
    }
    #endregion

}
