using UnityEngine;
using System.Collections;

//SCRIPT THAT IS RESPONSIBLE OF TAKING CARE OF PLAYER MELLEE ATTACK
public class MelleeAttack : MonoBehaviour
{
    public ButtonScript attackButton;
    //Layer mask that is helping to determine is hitted object enemy or not
    [SerializeField]
    private LayerMask _whatIsEnemy;
    private Animator _animator;

    //Position of area where player deals damage
    [SerializeField] private Transform _attackPos;
    //Radius of area where player deals damage
    private const float _attackRadius = 0.6f;
    //Array of hitted enemies colliders
    [SerializeField] private Collider[] enemiesToDealDamageTo;

    //Draws sphere in editor so its easier to adjust attack radius and position

    private void Awake()
    {
        _whatIsEnemy = LayerMask.GetMask("Enemy");
        _animator = gameObject.GetComponent<Animator>();
    }
    //Method that gets called whenever player hits enemy with mellee attack
    public void Attack()
    {
        _animator.SetBool("isAttacking", true);
        enemiesToDealDamageTo = Physics.OverlapSphere(_attackPos.transform.position, _attackRadius, _whatIsEnemy);

        foreach (Collider enemy in enemiesToDealDamageTo)
        {
            Enemy enemyToDealDamageTo = enemy.gameObject.GetComponent<Enemy>();
            StartCoroutine(enemyToDealDamageTo.TakeDamage());
        }
    }

    void Update()
    {

         if(Input.GetMouseButtonDown(0))
         {
            Attack();
         }
         if(Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("isAttacking", false);
        }
    }
}
