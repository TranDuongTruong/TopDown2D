using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : SaiMonoBehaviour
{
    
    [SerializeField] GhostCtrl ghostCtrl;

    public bool isAttacking = false;
    public float  range = 1;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        ghostCtrl = transform.parent.GetComponent<GhostCtrl>();
        
    }
    private void Update()
    {
        if (!ghostCtrl.canMove) return;
        UpdateTarget();
        if (isAttacking && !ghostCtrl.EnemyDamageReciver.takingDamage)
        {
           
            ghostCtrl.EnemyModelCtrl.ChangeModel("Attack");
        }
    }
    void UpdateTarget()
    {
       
       
    

             
            if (ghostCtrl.distanceToPlayer < range)
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
