using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossModelCtrl : SaiMonoBehaviour
{
  [SerializeField] public Animator animator;
    [SerializeField] BossCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadEnemyCtrl();
        animator = GetComponent<Animator>();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if(enemyCtrl == null) enemyCtrl=transform.parent.GetComponent<BossCtrl>();
    }





    public void SetAttack1()
    {
      
        animator.SetBool("Attack1", true);
    }
    public void SetAttack1Off()
    {
        enemyCtrl.canMove = true;
        animator.SetBool("Attack1", false);
    }
    public void SetAttack2()
    {
        
        animator.SetBool("Attack2", true);
    }
    public void SetAttack2Off()
    {
        enemyCtrl.canMove = true;
        animator.SetBool("Attack2", false);
        enemyCtrl.EnemyDamageReciver.gameObject.SetActive(true);
    }
    public void SetMove()
    {
       // enemyCtrl.canMove = true;
    
        animator.SetBool("walk", true);
  
    }
    public void SetMoveOff()
    {
        // enemyCtrl.canMove = true;

        animator.SetBool("walk", false);

    }
    public void ActiveSkill01()
    {
        enemyCtrl.EnemySpawner.SpawnEnemy("BlueGhost", 10);
    }
    public void ActiveSkill02()
    {
        enemyCtrl.EnemySpawner.SpawnEnemy("BlueGhost", 5);
        enemyCtrl.EnemySpawner.SpawnEnemy("BlackGhost",5);
        enemyCtrl.EnemySpawner.SpawnEnemy("Giant", 10);
        enemyCtrl.EnemySpawner.SpawnEnemy("Beetle", 10);
    }
}
