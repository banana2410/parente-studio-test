using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        _playerInput = gameObject.GetComponent<PlayerInput>();
        _animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        _animator.SetInteger("HorizInput", (int)_playerInput.input.x);
    }
}
