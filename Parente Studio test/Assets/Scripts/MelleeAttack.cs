using UnityEngine;

//SCRIPT THAT IS RESPONSIBLE OF TAKING CARE OF PLAYER MELLEE ATTACK
public class MelleeAttack : MonoBehaviour
{
    //Layer mask that is helping to determine is hitted object enemy or not
    [SerializeField]
    private LayerMask _whatIsEnemy;

    //Position of area where player deals damage
    [SerializeField] private Transform _attackPos;
    //Radius of area where player deals damage
    [SerializeField] private float _attackRadius;
    //Array of hitted enemies colliders
    [SerializeField] private Collider[] enemiesToDealDamageTo;

    //Draws sphere in editor so its easier to adjust attack radius and position
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPos.transform.position, _attackRadius);
    }

    //Method that gets called whenever player hits enemy with mellee attack
    public void DealDamage()
    {
        enemiesToDealDamageTo = Physics.OverlapSphere(_attackPos.transform.position, _attackRadius, _whatIsEnemy);
        foreach (Collider enemy in enemiesToDealDamageTo)
        {
            Enemy enemyToDealDamageTo = enemy.gameObject.GetComponent<Enemy>();
            enemyToDealDamageTo.TakeDamage();
        }
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            DealDamage();
        }
    }
}
