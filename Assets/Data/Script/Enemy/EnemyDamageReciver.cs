using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReciver : DamageReceiver
{
    public EnemyCtrl enemy;
    public bool takingDamage=false;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadEnemy();
    }
  
    public void LoadEnemy()
    {
        if (enemy != null) return;
        enemy=transform.parent.GetComponent<EnemyCtrl>();
    }
    public void TakeDamage(float damage)
    {
        takingDamage=true;
        this.Deduct(damage);

    }
    protected override void OnDead()
    {
      //  enemy.animator.SetBool("isDead", true);
        Destroy(transform.parent.gameObject);
    }

   

   

    

  

}
