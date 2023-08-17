using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDamageSender : SaiMonoBehaviour
{

    [SerializeField] List<EnemyCtrl> enemies = new List<EnemyCtrl>();
    [SerializeField] DespawnByTime despawn;

    [SerializeField] public float damage = 1;
    [SerializeField] public float time = 3;
    public FXSpawner fxSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadFxSpawner();
        despawn=transform.parent.GetComponentInChildren<DespawnByTime>();


    }
    protected virtual void LoadFxSpawner()
    {
        if (fxSpawner != null) return;
        fxSpawner = Transform.FindObjectOfType<FXSpawner>();
    }
    private void Update()
    {
        if(enemies.Count == 0)
        {
            return;
        }
        if (enemies[0] == null )
        {
            despawn.DespawnObject();
            return;
        }
        TakeDamage();
        if (transform.parent.name == "Ice") FreezeEnemy();
        if (enemies.Count > 0 && enemies[0] == null)
            transform.parent.transform.position = enemies[0].transform.position;
    }
    public void FreezeEnemy()
    {
        foreach (EnemyCtrl enemy in enemies)
        {
            enemy.PauseObject(time);
        }
    }
    public void TakeDamage()
    {
        for(int i=0;i<enemies.Count;i++)
        {
            if (enemies[i] == null) continue;
            enemies[i].EnemyDamageReciver.TakeDamage(damage);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamageReciver"))
        {

            EnemyCtrl enemyCtrl = collision.transform.parent.GetComponent<EnemyCtrl>();

           enemies.Add(enemyCtrl);
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamageReciver"))
        {

            EnemyCtrl enemyCtrl = collision.transform.parent.GetComponent<EnemyCtrl>();

            if (enemies.Contains(enemyCtrl))
            {

                enemies.Remove(enemyCtrl);
            }
        }
    }
}
