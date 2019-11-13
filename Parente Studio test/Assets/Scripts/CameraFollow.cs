using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Camera follow script
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerPos;
    [SerializeField] private Vector3 _offset;

    //Speed of camera movement
    [SerializeField] private float _speed;

    //Camera movement limits on y axis, to prevent camera going off the background and screen
    [SerializeField] private float _camMaxY;
    [SerializeField] private float _camMinY;

    private Rigidbody rb;

    //References
    private void Awake()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    //Sets game speed to normal
    private void Start()
    {
        Time.timeScale = 1f;
    }
    //Calling CameraMovement() here because it works better than in Update or FixedUpdate
    private void LateUpdate()
    {
       CameraMovement();
    }
    //Keeps track of player position and lerps towards its position adding the offset
    public void CameraMovement()
    {
        Vector3 desiredPos = _playerPos.transform.position + _offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, new Vector3(_playerPos.transform.position.x + _offset.x, Mathf.Clamp(_playerPos.position.y + _offset.y, _camMinY, _camMaxY), _playerPos.transform.position.z + _offset.z), _speed * Time.fixedDeltaTime);
        transform.position = smoothedPos;
    }


}
