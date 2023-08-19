using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] public PointCtrl pointCtrl;
    [SerializeField] public PlayerControler playerControler;
    [SerializeField]   public float timeLimit=5f;
    
    [SerializeField] public int countOfEnemies = 5;
    private List<int> availableSpawnIndices = new List<int>();

    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPlayer(); LoadPoints(); InitializeAvailableSpawnIndices();
    }
    protected virtual void LoadPlayer()
    {
        if (playerControler == null)
        {
            playerControler = Transform.FindObjectOfType<PlayerControler>();
        }
    }
    protected virtual void LoadPoints()
    {
        if (pointCtrl != null) return;
        pointCtrl=playerControler.transform.GetComponentInChildren<PointCtrl>();
    }
    protected override void Start()
    {
        base.Start();
        SpawnEnemy("Beetle", countOfEnemies); //InitializeAvailableSpawnIndices();
    }
    private void InitializeAvailableSpawnIndices()
    {
        availableSpawnIndices.Clear();
        for (int i = 0; i < pointCtrl.Waypoints.Count; i++)
        {
            availableSpawnIndices.Add(i);
        }
    }
   /* public void SpawnEnemy(string name, int count)
    {
        for(int i = 0; i < count; i++)
        {
            int index = Random.Range(0, pointCtrl.Waypoints.Count-1);
            Transform newEnemy = Spawn(name, pointCtrl.Waypoints[index].position, Quaternion.identity);
            newEnemy.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newEnemy.gameObject.SetActive(true);
        }
    }*/
    public void SpawnEnemy(string name, int count)
    {
        if (availableSpawnIndices.Count == 0)
        {
            InitializeAvailableSpawnIndices();
        }

        for (int i = 0; i < count; i++)
        {
            if (availableSpawnIndices.Count == 0)
            {
                break; // Không còn v? trí spawn kh? d?ng, d?ng vòng l?p
            }

            int randomIndex = Random.Range(0, availableSpawnIndices.Count);
            int spawnIndex = availableSpawnIndices[randomIndex];

            Transform spawnPoint = pointCtrl.Waypoints[spawnIndex];

            // Spawn enemy at the chosen spawn point
            Transform newEnemy = Spawn(name, spawnPoint.position, Quaternion.identity);
            newEnemy.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newEnemy.gameObject.SetActive(true);

            availableSpawnIndices.RemoveAt(randomIndex); // ?ánh d?u v? trí này ?ã ???c s? d?ng
        }
    }
  
}
