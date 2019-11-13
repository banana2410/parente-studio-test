using UnityEngine;
using System.Collections;

//BASE SCRIPT FOR ALL ENEMY ENTITIES IN GAME

public class Enemy : MonoBehaviour
{
    //is player dead or alive, if its dead it stops player movement
    public bool isDead;

    //Reference to player
    public GameObject player;

    //Enemy collider and animator components
    public Animator anim;
    public Collider enemyCollider;

    //Enemy targets only specific layer mask, player is tagged with Player layermask
    public LayerMask whatToTarget;


    //Start and end position to help determine should enemy attack player
    public Transform rayStart;
    public Transform rayEnd;

    //Reference to data container for player health
    [SerializeField]
    private TrackerScriptableObject _playerHealth;

    private Rigidbody _rb;


    //References to needed components declared above
    public virtual void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        enemyCollider = gameObject.GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = gameObject.GetComponent<Animator>();
    }


    //Method that is called whenever player attack and hit enemy, plays death animation and after that gets disabled
    public IEnumerator TakeDamage()
    {
        isDead = true;
        enemyCollider.enabled = false;
        if(_rb != null)
        {
            _rb.isKinematic = true;
        }

        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

}
