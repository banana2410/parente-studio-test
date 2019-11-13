using UnityEngine;
using System.Collections;

//SCRIPT FOR MOUSEENEMY TYPE OF ENEMY
public class MouseEnemy : Enemy
{
    //Is player in attack range?
    [SerializeField]
    private bool isInRange;

    //If is in range, should it attack?
    [SerializeField]
    private bool shouldAttack;

    //Patrol script reference
    private Patrol patrol;

    private void Start()
    {

    }

    //Calling base awake from Enemy.cs and sets up references from there + reference to Patrol component
    public override void Awake()
    {
        base.Awake();
        patrol = gameObject.GetComponent<Patrol>();
    }

    //Determines if player is in sight range, if it is, go towards him and attack him if is too close
    public void SetTarget()
    {
        shouldAttack = Vector3.Distance(player.transform.position, gameObject.transform.position) < 1.7f;
        isInRange = Physics.Linecast(rayStart.transform.position, rayEnd.transform.position, whatToTarget);
        if (!isInRange)
        {
            patrol.Speed = 1f;
            anim.SetBool("isWalking", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isFighting", false);
        }
        if (isInRange)
        {
            patrol.Speed = 1.3f;
            anim.SetBool("isRunning", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isFighting", false);
        }
        if (isInRange && shouldAttack)
        {
            anim.SetBool("isFighting", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", false);
        }
    }


    private void Update()
    {
        SetTarget();
    }
    
}
