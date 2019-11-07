using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _playerHealth;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            _playerHealth--;
            if(_playerHealth == 0)
            {
                //Game over
            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
