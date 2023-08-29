using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawnSystem : SaiMonoBehaviour
{
    [SerializeField] ItemDropSpawner spawner;
    [SerializeField] PointCtrl points;
    [SerializeField] List<Transform> pointsSpawned;
    [SerializeField] List<Transform> currentExp;

    [SerializeField] protected ShootableObjectSO shootableObject;
    [SerializeField] PlayerControler playerControler;
    [SerializeField] int numToSpawn = 10;
    [SerializeField] float time = 30;
    [SerializeField] float originalTime = 30;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadAllComponents();

    }
    private void LoadAllComponents()
    {
        if(spawner==null) spawner=Transform.FindObjectOfType<ItemDropSpawner>();
        if(playerControler==null) playerControler=Transform.FindObjectOfType<PlayerControler>();
        if(points==null) points=playerControler.transform.GetComponentInChildren<PointCtrl>();
    }
    private void Update()
    {
        if (pointsSpawned.Count == points.Waypoints.Count)
        {
            pointsSpawned.Clear();
        }
        
        if (numToSpawn > 0)
        {
            int index = 0;
            do
            {
                index = Random.Range(0, points.Waypoints.Count);
            } while (pointsSpawned.Contains(points.Waypoints[index]));
            pointsSpawned.Add(points.Waypoints[index]);
            spawner.Drop(shootableObject.dropList, points.Waypoints[index].transform.position, Quaternion.identity);
            numToSpawn--;
        }else if (time <= 0)
        {
            numToSpawn += 20;
            
            time = originalTime + originalTime / 2;
        }
        else
        {
            time-=Time.deltaTime;
        }
    }


}
