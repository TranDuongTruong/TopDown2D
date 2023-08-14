using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjShooting : SaiMonoBehaviour
{
    [SerializeField] List<EnemyCtrl> collidedEnemies = new List<EnemyCtrl>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamageReciver"))
        {

            EnemyCtrl  enemyCtrl = collision.transform.parent.GetComponent<EnemyCtrl>();
            
           collidedEnemies.Add(enemyCtrl);
        }
       
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamageReciver"))
        {

            EnemyCtrl enemyCtrl = collision.transform.parent.GetComponent<EnemyCtrl>();

            if (collidedEnemies.Contains(enemyCtrl))
            {
                collidedEnemies.Remove(enemyCtrl);
            }
        }
    }

    private void Update()
    {
        // Ki?m tra va ch?m và x? lý enemy trong danh sách
        foreach (EnemyCtrl enemy in collidedEnemies)
        {
            if (enemy != null)
            {
                
            }
        }
    }
}
