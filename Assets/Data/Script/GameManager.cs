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
    private void Update()
    {
        time+=Time.deltaTime;
        if (time >= nextSpawnTime)
        {
            enemySpawner.SpawnEnemy("BlueGhost",20); // G?i hàm Spawn c?a enemySpawner

            // C?p nh?t th?i ?i?m spawn ti?p theo d?a trên kho?ng th?i gian spawnInterval
            nextSpawnTime += spawnInterval;

            // Ki?m tra các ?i?u ki?n khác (2 phút, 4 phút, 5 phút) và g?i hàm Spawn t??ng t?
            // N?u c?n, b?n có th? s? d?ng c?u trúc if ho?c switch-case ?? xác ??nh th?i ?i?m spawn
        }
    }
}
