using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] public PointCtrl pointCtrl;
    [SerializeField] public PlayerControler playerControler;
    [SerializeField]   public float timeLimit=5f;
    [SerializeField] public float time = 0;

   protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPlayer(); LoadPoints();
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
        SpawnEnemy("Ghost",5);
    }
    protected virtual void SpawnEnemy(string name, int count)
    {
        for(int i = 0; i < count; i++)
        {
            int index = Random.Range(0, pointCtrl.Waypoints.Count-1);
            Transform newEnemy = Spawn(name, pointCtrl.Waypoints[index].position, Quaternion.identity);
            newEnemy.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            newEnemy.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        time+=Time.deltaTime;
        if (time > timeLimit)
        {
            SpawnEnemy("Ghost", 5);
            time=0;
        }

    }
}
