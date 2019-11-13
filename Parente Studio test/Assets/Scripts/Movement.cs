using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//SCRIPT THAT IS RESPONSIBLE FOR MOVING THE PLAYER 
//[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [Header("References and constants")]

    public Transform feetPos;
    private Rigidbody _rb;
    private Animator _animator;
    private PlayerInput playerInput;
    private const float distanceToGround = 0.2f;
    private Vector3 rotation;

    [Header("Variables")]
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    public bool _isGrounded;

    //What is ground
    public LayerMask whatIsGround;


    void Start()
    {
        rotation = new Vector3(0f, 90f, 0f);
    }
    private void Awake()
    {
        //Setting references and initial values
        _animator = gameObject.GetComponent<Animator>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        _rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
        if (ShouldJump())
        {
            Jump();
        }
    }
    private void Update()
    {
        isGrounded();
        if (_rb.velocity.x == 0f)
        {
            _animator.SetBool("isMoving", false);
        }
    }


    //Checks if player pressed the jump button and if it is grounded, if is, player is allowed to jump
    public bool ShouldJump()
    {
        return playerInput.input.y > 0;
    }

    //Checks if player is grounded
    private void isGrounded()
    {
        _isGrounded = Physics.Raycast(feetPos.transform.position, Vector2.down, distanceToGround, whatIsGround);
    }
    //Adds upwards vertical force to player
    public void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
        }
    }

    //Grabs player input and changing its velocity and rotation according to that, causing it to move and rotate accordingly
    public void Move()
    {
        _animator.SetBool("isMoving", true);
        _rb.velocity = new Vector2(playerInput.input.x * _speed, _rb.velocity.y);
        if (playerInput.input.x > 0)
        {
            transform.rotation = Quaternion.Euler(rotation);
        }
        if (playerInput.input.x < 0)
        {
            transform.rotation = Quaternion.Euler(-rotation);
        }


    }


    //Sets player parent to moving platform to follow it where it moves
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.SetParent(collision.gameObject.transform);
        }
    }
    //Sets player parent to null
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "MovingPlatform")
        {
            gameObject.transform.SetParent(null);
        }
    }

}
