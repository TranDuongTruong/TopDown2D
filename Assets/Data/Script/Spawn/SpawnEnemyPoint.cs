using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyPoint : SaiMonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected bool canSpawn=false;
    [SerializeField] protected List<string> enemyNames = new List<string>();
    [SerializeField] public PointCtrl pointCtrl;
    [SerializeField] protected int numOfSpawn = 1;
    [SerializeField] protected int spawnCount = 0;

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
        if (!canSpawn || numOfSpawn <= 0)
        {
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            // Ch?n m?t enemyName ng?u nhiên trong danh sách
            string randomEnemyName = enemyNames[Random.Range(0, enemyNames.Count)];

             enemySpawner.SpawnEnemy(randomEnemyName, i,pointCtrl.Waypoints);
           // spawnedEnemies.Add(spawnedEnemy.gameObject);
           
        } 
        canSpawn = false;
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
