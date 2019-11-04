using UnityEngine;

//SCRIPT THAT IS RESPONSIBLE FOR CHANGING PLAYER ANIMATION ACCORDING TO MOVEMENT AND ACTIONS
public class AnimationController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Animator _animator;

    private void Awake()
    {
        _playerInput = gameObject.GetComponent<PlayerInput>();
        _animator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        _animator.SetInteger("HorizInput", (int)_playerInput.input.x);
        
    }
}
