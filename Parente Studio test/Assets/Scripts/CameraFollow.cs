using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerPos;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;
    private Rigidbody rb;

    private void Awake()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
       CameraMovement();
    }
    public void CameraMovement()
    {
        Vector3 desiredPos = _playerPos.transform.position + _offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, new Vector3(_playerPos.transform.position.x + _offset.x, Mathf.Clamp(_playerPos.position.y + _offset.y, 0.25f, 3.4f), _playerPos.transform.position.z + _offset.z), _speed * Time.fixedDeltaTime);
        transform.position = smoothedPos;
    }


}
