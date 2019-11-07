using UnityEngine;

//SCRIPT THAT IS RESPONSIBLE FOR MOVING THE PLAYER 
//[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    //Speed of movement
    [SerializeField] private float _speed;
    //Jump height
    [SerializeField] private float _jumpHeight;
    //Reference to player input script
    private PlayerInput playerInput;
    public float FallingSpeed;

    private Rigidbody _rb;


    [SerializeField] private bool _isGrounded;
    //Helps determine if player had already made the jump
    public bool alreadyJumped;

    //Vector3 for storing rotation of player and readjusting it depending about where the player is facing
    public Vector3 rotation;

    void Start()
    {
        rotation = new Vector3(0f, 90f, 0f);
    }
    private void Awake()
    {
        //Setting references and initial values
        alreadyJumped = false;
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
        
    }


    //Checks if player pressed the jump button and if it is grounded, if is, player is allowed to jump
    public bool ShouldJump()
    {
        return playerInput.input.y > 0;
    }

    //Adds upwards vertical force to player, causing it to jump, also setting jump check to true, so player cant do double jump
    public void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x , _jumpHeight);
        }
    }

    //Grabs player input and changing its velocity and rotation according to that, causing it to move and rotate accordingly
    public void Move()
    {
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

    #region Touch controls
    public void MoveRight()
    {
        Debug.Log("A");
        _rb.velocity = new Vector2(1f * _speed, _rb.velocity.y);
        transform.rotation = Quaternion.Euler(rotation);
    }
    public void MoveLeft()
    {
        Debug.Log("A");
        _rb.velocity = new Vector2(-1f * _speed, _rb.velocity.y);
        transform.rotation = Quaternion.Euler(-rotation);
    }

    #endregion

    //Ground check 
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            alreadyJumped = false;
            _isGrounded = true;
        }
    }

    //Ground exit check
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}
