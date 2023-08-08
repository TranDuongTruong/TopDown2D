using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] public PointCtrl pointCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPoints();
    }
    protected virtual void LoadPoints()
    {
        if (pointCtrl != null) return;
        pointCtrl=transform.GetComponentInChildren<PointCtrl>();
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
            newEnemy.gameObject.SetActive(true);
        }
    }
}
