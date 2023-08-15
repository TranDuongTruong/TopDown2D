using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSystem : SaiMonoBehaviour
{
    [SerializeField] List<PointCtrl> points;
    public List<PointCtrl> Points => points;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadWayPoint();
    }
    protected virtual void LoadWayPoint()
    {
        if (points.Count > 0) return;
        PointCtrl[] pointCtrls = transform.GetComponentsInChildren<PointCtrl>();

        List<PointCtrl> tempPoints = new List<PointCtrl>();
        foreach (PointCtrl t in pointCtrls)
        {
            tempPoints.Add(t);
        }

        points = tempPoints;
    }
}
