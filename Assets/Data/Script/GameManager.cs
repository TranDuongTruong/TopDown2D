using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SaiMonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected ItemDropSpawner itemDropSpawner;
    [SerializeField] protected PlayerControler playerControler;
    [SerializeField] protected FinishGateCtrl finishGateCtrl;
    [SerializeField] protected BossSystem bossSystem;
    public BossSystem BossSystem => bossSystem;

    [SerializeField] public int killCount;
    [SerializeField] protected float time = 0;
    [SerializeField] protected float spawnInterval = 20; // Th?i gian gi?a các l?n spawn
    private float nextSpawnTime = 30;// Th?i ?i?m s? spawn ti?p theo (1 phút ??u tiên)
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadComponent(); LoadPlayer();
    }
    protected virtual void LoadComponent()
    {
        if (enemySpawner == null) enemySpawner=Transform.FindObjectOfType<EnemySpawner>();
        if (bossSystem == null) bossSystem=Transform.FindObjectOfType<BossSystem>();
        if (itemDropSpawner == null) itemDropSpawner=Transform.FindObjectOfType<ItemDropSpawner>();
        if (finishGateCtrl == null) finishGateCtrl=Transform.FindObjectOfType<FinishGateCtrl>();
        finishGateCtrl.gameObject.SetActive(false);


    }
    protected virtual void LoadPlayer()
    {
        if(playerControler==null) playerControler=Transform.FindObjectOfType<PlayerControler>();
    }
    protected override void  Awake()
    {
        instance = this;
        enemySpawner.SpawnEnemy("BlueGhost", 20);
    }
    int currentCount=10;
    private void Update()
    {
        if (bossSystem.isDead)
        {
            finishGateCtrl.gameObject.SetActive(true);
        }
        else
        {
            time += Time.deltaTime;
            if (enemySpawner.SpawnedCount <= 0&&time>2)
            {
                enemySpawner.SpawnEnemy("GreenGhost", currentCount); enemySpawner.SpawnEnemy("BlueGhost", currentCount);

                currentCount += 3;
                time = 0;

            }else
            if (time >= nextSpawnTime)
            {
                if (playerControler.PlayerStatus.level == 4)
                {
                    enemySpawner.SpawnEnemy("GreenGhost", 5); enemySpawner.SpawnEnemy("BlueGhost", 5);
                }
                else if (playerControler.PlayerStatus.level == 6)
                {
                    enemySpawner.SpawnEnemy("GreenGhost", 10);
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
                    enemySpawner.SpawnEnemy("BlueGhost", 2);
                    enemySpawner.SpawnEnemy("BlackGhost", 3);

                }
                time = 0;
                nextSpawnTime -= 0.2f;


            }
        }
    }
}
