using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SaiMonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected ItemDropSpawner itemDropSpawner;
    [SerializeField] protected PlayerControler playerControler;

    [SerializeField] protected float time = 0;
    [SerializeField] protected float spawnInterval = 20; // Th?i gian gi?a c�c l?n spawn
    private float nextSpawnTime = 30;// Th?i ?i?m s? spawn ti?p theo (1 ph�t ??u ti�n)
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
            enemySpawner.SpawnEnemy("BlueGhost",20); // G?i h�m Spawn c?a enemySpawner

            // C?p nh?t th?i ?i?m spawn ti?p theo d?a tr�n kho?ng th?i gian spawnInterval
            nextSpawnTime += spawnInterval;

            // Ki?m tra c�c ?i?u ki?n kh�c (2 ph�t, 4 ph�t, 5 ph�t) v� g?i h�m Spawn t??ng t?
            // N?u c?n, b?n c� th? s? d?ng c?u tr�c if ho?c switch-case ?? x�c ??nh th?i ?i?m spawn
        }
    }
}
