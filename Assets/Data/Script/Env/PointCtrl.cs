using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCtrl :SaiMonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    public List<Transform> Waypoints => waypoints;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadWayPoint();
    }
     protected virtual void LoadWayPoint()
    {
        if (waypoints.Count > 0) return;
        Transform[] points = transform.GetComponentsInChildren<Transform>();

        foreach (Transform t in points)
        {
            if (t == this.transform) continue;
            waypoints.Add(t);
            
        }
       
    }
}
