using UnityEngine;

//BASE SCRIPT FOR ALL ENEMY ENTITIES IN GAME
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    //Reference to data container for player health
    [SerializeField]
    private TrackerScriptableObject _playerHealth;
    //Enemy health variable, default value is 3
    [SerializeField]
    private int _health;

    private Rigidbody _rb;


    void Start()
    {
        _health = 3;
    }
    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    //Method that is called whenever player attack and hit enemy
    public void TakeDamage()
    {
        _health--;
        Debug.Log("Taking damage!");
        if(_health == 0)
        {
            gameObject.SetActive(false);
            Debug.Log("Dead");
        }
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            _playerHealth.Value--;
        }
    }*/
}
