using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 _startPos;
     private Vector3 _targetPos;
    private Vector3 _nextPos;
    private float _speed;
    [SerializeField] private float _posIncrement;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 1.5f;
        _nextPos = _targetPos;
    }
    private void Awake()
    {
        _startPos = gameObject.transform.position;
        _targetPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + _posIncrement, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    public void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, _nextPos, _speed * Time.deltaTime);
        if (gameObject.transform.position.y == _nextPos.y)
        {
            _nextPos = _startPos;
        }
        if (gameObject.transform.position.y == _nextPos.y)
        {
            _nextPos = _targetPos;
        }
    }
}
