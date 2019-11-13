using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Start pos of platform
    private Vector3 _startPos;
    //startpos+desiredpos
    private Vector3 _targetPos;
    //Where we want to move it
    private Vector3 _desiredPos;

    //Speed of platform
    private float _speed;

    //Where we want to move platform
    [SerializeField] private Vector3 _whereToMove;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 1.5f;
    }
    //Setting startpos to current position, desiredpos to startpos+ wheretomove, targetpos is desiredpos after calculation
    private void Awake()
    {
        _startPos = gameObject.transform.position;
        _desiredPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z) + _whereToMove;
        _targetPos = _desiredPos;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    //Moves platform
    public void MovePlatform()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPos, _speed * Time.deltaTime);
        if (gameObject.transform.position == _targetPos)
        {
            _targetPos = _startPos;
        }
        if (gameObject.transform.position == _startPos)
        {
            _targetPos = _desiredPos;
        }
    }
}
