using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance => instance;
    [SerializeField] public PointCtrl pointCtrl;
    [SerializeField] public PlayerControler playerControler;
    [SerializeField]   public float timeLimit=5f;
    [SerializeField] List<Transform> points;
    [SerializeField] public int countOfEnemies = 5;
    [SerializeField] private List<int> availableSpawnIndices = new List<int>();
    [SerializeField] protected bool canSpawn = true;
    public bool CanSpawn
    {
        get { return canSpawn; }
        set { canSpawn = value; }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPlayer(); LoadPoints();// InitializeAvailableSpawnIndices();
    }
    protected override void Awake()
    {
        base.Awake();
        instance = this;
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
       // SpawnEnemy("Beetle", countOfEnemies); //InitializeAvailableSpawnIndices();
    }
    private void InitializeAvailableSpawnIndices(List<Transform> points)
    {
        availableSpawnIndices.Clear();
        for (int i = 0; i < points.Count; i++)
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
        if(!canSpawn) return;
        if (availableSpawnIndices.Count == 0)
        {
            InitializeAvailableSpawnIndices(pointCtrl.Waypoints);
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
    public void SpawnEnemy(string name, int count, List<Transform> points)
    {
        if (!canSpawn) return;
        /* if (availableSpawnIndices.Count == 0)
         {
             InitializeAvailableSpawnIndices(points);
         }*/

        for (int i = 0; i < count; i++)
        {
           /* if (availableSpawnIndices.Count == 0)
            {
                break; // Không còn v? trí spawn kh? d?ng, d?ng vòng l?p
            }*/

            int randomIndex = Random.Range(0, points.Count);
         
           
            Transform spawnPoint = points[randomIndex];
            
            // Spawn enemy at the chosen spawn point
            Transform newEnemy = Spawn(name, spawnPoint.position, Quaternion.identity);
            newEnemy.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newEnemy.gameObject.SetActive(true);

            //availableSpawnIndices.RemoveAt(randomIndex); // ?ánh d?u v? trí này ?ã ???c s? d?ng
        }
    }
    private void Update()
    {
        if (!canSpawn)
        {
            Transform [] objs=holder.transform.GetComponentsInChildren<Transform>();
            foreach(Transform obj in objs)
            {
                if(obj!=holder)
                obj.gameObject.SetActive(false);
            }
        }
    }
}
