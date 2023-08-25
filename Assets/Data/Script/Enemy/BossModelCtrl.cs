using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossModelCtrl : SaiMonoBehaviour
{
    [SerializeField] protected List<string> enemyNames ;
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
        SpawnEnemy(5);
    }
    public void ActiveSkill02()
    {
        SpawnEnemy(10);
    }
    private void SpawnEnemy(int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {      
            string randomEnemyName = enemyNames[Random.Range(0, enemyNames.Count)];
            enemyCtrl.EnemySpawner.SpawnEnemy(randomEnemyName, i);
        }
    }
}
