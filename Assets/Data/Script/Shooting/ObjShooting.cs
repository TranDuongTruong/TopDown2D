using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjShooting : SaiMonoBehaviour
{
    [SerializeField] List<EnemyCtrl> collidedEnemies = new List<EnemyCtrl>();
    [SerializeField] BulletSpawner spawner;
    [SerializeField] float damage = 3f;
    [SerializeField] float speed = 30;
    [SerializeField] float time = 0;
    [SerializeField] float delay = 1;
    [SerializeField] string bulletName = "Spirit";


    protected override void LoadComponents()
    {
        base.LoadComponents();
        spawner=Transform.FindObjectOfType<BulletSpawner>();
    }
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
       time+=Time.deltaTime;
        if(time > delay)
        {
            foreach (EnemyCtrl enemy in collidedEnemies)
            {
                 if (enemy != null)
                    {
                         Shooting(enemy,damage,speed);
                    break;
                    }
            }
            time=0;
        }
       
    }
    public void Shooting(EnemyCtrl enemy, float damage, float speed)
    {
        Transform newBullet=spawner.Spawn(bulletName + transform.parent.name, transform.parent.position, Quaternion.identity);
        newBullet.gameObject.SetActive(true);
        BulletControler bulletControler=newBullet.GetComponent<BulletControler>();
        if(bulletControler != null)
        {
            bulletControler.bulletFly.SetSpeed(speed);
            bulletControler.bulletFly.SetTarget(enemy.transform);
            bulletControler.BulletDamageSender.damage = damage;
        }
    }
}
