using System.Collections;
using UnityEngine;

//Health component on player
public class Health : MonoBehaviour
{
    public GameObject DeathScreen;
    //Is player invincible?
    private bool invincible;

    private Rigidbody _rb;

    //Player health data container
    [SerializeField] private TrackerScriptableObject _playerHealth;


    //What happens when player collides with enemy, if its hurt, wait for 2 seconds before it can take damage again
    private void OnCollisionEnter(Collision collision)
    {
        if(!invincible)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _playerHealth.Value--;
                invincible = true;
                Invoke("isVunerableAgain", 2f);
            }

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();      
    }

    public void isVunerableAgain()
    {
        invincible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_playerHealth.Value == 0)
        {
            DeathScreen.SetActive(true);
            _playerHealth.Value = 1;
            Time.timeScale = 0f;
        }
    }
}
