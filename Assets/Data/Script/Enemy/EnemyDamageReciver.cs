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
        GameManager.Instance.killCount++;
        //  enemy.animator.SetBool("isDead", true);
        OnDeadDrop();
      //  Destroy(transform.parent.gameObject);
      enemy.EnemyDespawn.DespawnObject();
    }
    protected virtual void OnDeadDrop()
    {
        if(transform==null||this.enemy==null) return; 
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        
        ItemDropSpawner.Instance.Drop(this.enemy.ShootableObject.dropList, dropPos, dropRot);
    }








}
