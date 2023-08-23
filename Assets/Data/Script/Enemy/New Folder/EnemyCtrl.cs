using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : SaiMonoBehaviour
{
    [SerializeField] protected PlayerControler playerControler;
    public PlayerControler PlayerControler => playerControler;

    [SerializeField] protected EnemyModelCtrl enemyModelCtrl;
    public EnemyModelCtrl EnemyModelCtrl => enemyModelCtrl;

   // [SerializeField]    public Rigidbody2D rb;
    [SerializeField] protected EnemyAttack enemyAttack;
    public EnemyAttack EnemyAttack => enemyAttack;
    [SerializeField] protected EnemyDamageReciver enemyDamageReciver;
    public EnemyDamageReciver EnemyDamageReciver => enemyDamageReciver;
    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn => enemyDespawn;
    /* [SerializeField] protected EnemyMovement enemyMovement;
     public EnemyMovement EnemyMovement => enemyMovement;*/
    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;
    [SerializeField] public bool canMove=true;
    [SerializeField] public bool normalEnemy=true;
    [SerializeField] protected float distanceToPlayer = 0;
    public float DistanceToPlayer => distanceToPlayer;  
    public void PauseObject(float time)
    {
       canMove=false;
        Invoke("ActiveOject", time);
    }
    public void ActiveOject()
    {
        canMove = true;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadDamageReciver(); LoadModelCtrl(); LoadEnemyAttack(); LoadPlayer();
    }
    protected virtual void LoadDamageReciver()
    {
        if (enemyDamageReciver == null)
        {
            enemyDamageReciver = transform.GetComponentInChildren<EnemyDamageReciver>();
        }
    }
    protected virtual void LoadDespawr()
    {
        if (enemyDespawn == null)
        {
            enemyDespawn = transform.GetComponentInChildren<EnemyDespawn>();
        }
    }
    protected virtual void LoadModelCtrl()
    {
        if (enemyModelCtrl == null)
        {
            enemyModelCtrl = transform.GetComponentInChildren<EnemyModelCtrl>();
        }
    }
    protected virtual void LoadEnemyAttack()
    {
        if (enemyAttack == null)
        {
            enemyAttack = transform.GetComponentInChildren<EnemyAttack>();
        }
    }
    protected virtual void LoadPlayer()
    {
        if (playerControler == null)
        {
            playerControler = Transform.FindObjectOfType<PlayerControler>();
        }
    }
}
