using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bee enemy script that inherits from base Enemy.cs
public class BeeEnemy : Enemy
{
    //Sets up references from base class
    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        BeeAttack();
    }
    //If plaer is close enough, attack it!
    public void BeeAttack()
    {
        if (Physics.Linecast(rayStart.transform.position, rayEnd.transform.position, whatToTarget))
        {
            anim.SetBool("isAttacking", true);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("Idle", true);
        }
    }
}
