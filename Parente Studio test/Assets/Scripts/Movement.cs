using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    private PlayerInput playerInput;
    private Rigidbody _rb;
    [SerializeField] private bool _isGrounded;
    public bool initialForce;

    void Start()
    {

    }
    private void Awake()
    {
        //Setting references and initial values
        initialForce = true;
        playerInput = gameObject.GetComponent<PlayerInput>();
        _rb = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector2(playerInput.input.x * _speed * Time.fixedDeltaTime, _rb.velocity.y);
        if (ShouldJump())
        {
            Jump();
        }

    }

    public bool ShouldJump()
    {
        return playerInput.input.y > 0;
    }
    public void Jump()
    {
        if (initialForce)
        {
            _rb.AddForce(Vector2.up * Time.fixedDeltaTime * _jumpHeight, ForceMode.Impulse);
            initialForce = false;
        }
    }

    public void Move()
    {
        //dodat okricanje za 90 po y, ovisi u koju stranu setas, malo jos brzinu i animaciju dovest u red
        _rb.velocity = Vector2.right * playerInput.input.x * Time.fixedDeltaTime * _speed;
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            initialForce = true;
            _isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}
