using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private TrackerScriptableObject _playerHealth;
    public Rigidbody _rb;


    void Start()
    {
        
    }
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _playerHealth.Value--;
        }
    }
}
