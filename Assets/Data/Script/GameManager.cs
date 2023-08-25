using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SaiMonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected ItemDropSpawner itemDropSpawner;
    [SerializeField] protected PlayerControler playerControler;

    [SerializeField] protected float time = 0;
    [SerializeField] protected float spawnInterval = 20; // Th?i gian gi?a các l?n spawn
    private float nextSpawnTime = 30;// Th?i ?i?m s? spawn ti?p theo (1 phút ??u tiên)
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadSpawner(); LoadPlayer();
    }
    protected virtual void LoadSpawner()
    {
        if (enemySpawner == null) enemySpawner=Transform.FindObjectOfType<EnemySpawner>();
        if (itemDropSpawner == null) itemDropSpawner=Transform.FindObjectOfType<ItemDropSpawner>();

    }
    protected virtual void LoadPlayer()
    {
        if(playerControler==null) playerControler=Transform.FindObjectOfType<PlayerControler>();
    }
    protected override void  Awake()
    {
        enemySpawner.SpawnEnemy("BlueGhost", 20);
    }
    private void Update()
    {
        time+=Time.deltaTime;
        if (time >= nextSpawnTime)
        {
            if (playerControler.PlayerStatus.level == 4)
            {
                enemySpawner.SpawnEnemy("GreenGhost", 10); enemySpawner.SpawnEnemy("BlueGhost", 10);
            }
            else if (playerControler.PlayerStatus.level == 6)
            {
                enemySpawner.SpawnEnemy("GreenGhost", 20);
                enemySpawner.SpawnEnemy("BlueGhost", 5);
                enemySpawner.SpawnEnemy("BlackGhost", 5);
            }
            else if (playerControler.PlayerStatus.level == 8)
            {
                enemySpawner.SpawnEnemy("GoldGhost", 5);
                enemySpawner.SpawnEnemy("GreenGhost", 20);
                enemySpawner.SpawnEnemy("BlueGhost", 5);
                enemySpawner.SpawnEnemy("BlackGhost", 5);
            }
            else
            {
            enemySpawner.SpawnEnemy("BlueGhost",10);
            enemySpawner.SpawnEnemy("BlackGhost",10);

            }
            time = 0;
            nextSpawnTime -= 0.2f;

           
        }
    }
}
