using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : SaiMonoBehaviour
{
    [SerializeField] protected EnemyModelCtrl enemyModelCtrl;
    public EnemyModelCtrl EnemyModelCtrl => enemyModelCtrl;

   // [SerializeField]    public Rigidbody2D rb;
    [SerializeField] protected EnemyAttack enemyAttack;
    public EnemyAttack EnemyAttack => enemyAttack;
    [SerializeField] protected EnemyDamageReciver enemyDamageReciver;
    public EnemyDamageReciver EnemyDamageReciver => enemyDamageReciver;
   /* [SerializeField] protected EnemyMovement enemyMovement;
    public EnemyMovement EnemyMovement => enemyMovement;*/


}
