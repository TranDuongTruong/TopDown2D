using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : EnemyCtrl
{
    [SerializeField] protected EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner => enemySpawner;
    [SerializeField] protected BossModelCtrl bossModelCtrl;
   
  public BossModelCtrl BossModelCtrl=>bossModelCtrl;
    [SerializeField] protected BossMovement bossMovement;
  
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadSpawner(); 
        bossModelCtrl=transform.GetComponentInChildren<BossModelCtrl>();
        bossMovement=transform.GetComponentInChildren<BossMovement>();
        
    }
    protected virtual void LoadSpawner()
    {
        if (enemySpawner == null) enemySpawner = Transform.FindObjectOfType<EnemySpawner>();
      

    }
    public float delay = 19;
    public float time = 0;
    public bool canAttack=true;
    public bool canAttackFinalSkill=true;
    private void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, playerControler.transform.position);
        if (enemyDamageReciver.HP <= enemyDamageReciver.HPMax / 4&& canAttackFinalSkill)
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaa");
            canMove = false;
            delay /= 2;
            enemyDamageReciver.transform.gameObject.SetActive(false);
            bossModelCtrl.SetAttack2();
            canAttackFinalSkill = false;
        }else 
        if (enemyAttack.isAttacking&& canAttack)
        {

            canMove = false;

            bossModelCtrl.SetAttack1();

            canAttack = false;
        }
        else
        {
            if (canAttack == false)
            {
                time += Time.deltaTime;
                if (time > delay)
                {
                    canAttack = true;
                    time = 0;   
                }
            }

        }
       
    }
}
