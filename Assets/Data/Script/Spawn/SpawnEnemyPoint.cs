using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyPoint : SaiMonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected bool canSpawn=false;
    [SerializeField] protected List<string> enemyNames = new List<string>();
    [SerializeField] public PointCtrl pointCtrl;
    [SerializeField] protected int numOfSpawn = 2;
    [SerializeField] protected int spawnCount = 2;

    protected List<GameObject> spawnedEnemies = new List<GameObject>();
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadSpawner(); 
        pointCtrl = GetComponent<PointCtrl>();
    }
    protected virtual void LoadSpawner()
    {
        if (enemySpawner == null) enemySpawner = Transform.FindObjectOfType<EnemySpawner>();

    }
    private void Update()
    {
        
      if(canSpawn&&numOfSpawn>0)  SpawnEnemy();
      
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            string randomEnemyName = enemyNames[Random.Range(0, enemyNames.Count)];
         
            enemySpawner.SpawnEnemy(randomEnemyName, spawnCount, pointCtrl.Waypoints);
        }
        numOfSpawn--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canSpawn = true;
        }
    }
}
