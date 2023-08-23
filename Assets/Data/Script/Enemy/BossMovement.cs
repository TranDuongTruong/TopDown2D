using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : SaiMonoBehaviour
{
    [SerializeField] BossCtrl enemyCtrl;
    [SerializeField] List<Transform> waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] float currentSpeed = 1;
    [SerializeField] float scale = .5f;

    [SerializeField] PointCtrl waypointCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadEnemyCtrl();
        LoadWayPoints();
    }

    protected virtual void LoadWayPoints()
    {
        foreach (var waypoint in waypointCtrl.Waypoints)
        {
            waypoints.Add(waypoint);
        }
    }
    private void Update()
    {
        if (enemyCtrl.canMove)
        { enemyCtrl.BossModelCtrl.SetMove();
            MoveToWaypoint();
           
        }
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl == null) enemyCtrl = transform.parent.GetComponent<BossCtrl>();
    }
    private void MoveToWaypoint()
    {
        if (waypoints.Count > 0)
        {
            if (currentWaypointIndex >= waypoints.Count) // If we've reached the last waypoint, wrap around to the beginning
            {
                currentWaypointIndex = 0;
            }

            Vector2 targetPosition = waypoints[currentWaypointIndex].position;

            if (Vector2.Distance(transform.parent.position, targetPosition) < 0.1f) // If we've reached the target position, move to the next waypoint
            {
                currentWaypointIndex++;
            }
            else // Otherwise, move towards the target position
            {
                Vector2 direction = targetPosition - (Vector2)transform.parent.position;
                transform.parent.position += (Vector3)direction.normalized * currentSpeed * Time.deltaTime;
            }
            if (targetPosition.x > transform.parent.position.x) transform.parent.localScale = new Vector3(-scale, scale, scale);
            else if (targetPosition.x <transform.parent.position.x) transform.parent.localScale = new Vector3(scale, scale, scale);
        }
    }
}
