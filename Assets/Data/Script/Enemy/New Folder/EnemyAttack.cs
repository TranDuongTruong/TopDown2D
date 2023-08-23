using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : SaiMonoBehaviour
{
    
    [SerializeField] EnemyCtrl enemyCtrl;

    public bool isAttacking = false;
    public float  range = 1;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        
    }
    private void Update()
    {
        if (!enemyCtrl.canMove) return;
        UpdateTarget();
        if (enemyCtrl.normalEnemy) Attacking();
       // else BossAttacking();
    }
    private void BossAttacking()
    {

    }
    private void Attacking()
    {
        if (isAttacking && !enemyCtrl.EnemyDamageReciver.takingDamage)
        {

            enemyCtrl.EnemyModelCtrl.ChangeModel("Attack");
        }
    }

    void UpdateTarget()
    {
             
            if (enemyCtrl.DistanceToPlayer < range)
            {
                isAttacking=true;
                
            } else isAttacking=false;
        

        

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);

    }
   
}
