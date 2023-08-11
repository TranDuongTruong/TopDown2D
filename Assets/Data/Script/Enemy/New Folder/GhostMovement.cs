using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GhostMovement : SaiMonoBehaviour
{
   
    [SerializeField] GhostCtrl ghostCtrl;
    

    [SerializeField] float moveSpeed = 1;
    [SerializeField] float scale = .5f;
    [SerializeField] List <Transform> waypoints; 
    [SerializeField] PointCtrl waypointCtrl;
    private int currentWaypointIndex = 0; 

    protected override void LoadComponents()
    {
        base.LoadComponents();
        ghostCtrl=transform.parent.GetComponent<GhostCtrl>();
        LoadPlayer();
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
       

  
        
        if (ghostCtrl.distanceToPlayer <= 1.5f&& !ghostCtrl.EnemyAttack.isAttacking||  ghostCtrl.EnemyDamageReciver.takingDamage)
        {
            Debug.Log("aaa");
            ghostCtrl.EnemyModelCtrl.ChangeModel("Run");
            if (ghostCtrl.EnemyDamageReciver.takingDamage) moveSpeed = -15f;
           else moveSpeed = 1.25f;

            ChasePlayer();
            ghostCtrl.EnemyDamageReciver.takingDamage = false;
        }
        else if(!ghostCtrl.EnemyAttack.isAttacking)
        {
            ghostCtrl.EnemyModelCtrl.ChangeModel("Run");
            moveSpeed = 1;
            ChasePlayer();
            //MoveToWaypoint();
        }
    }

    protected virtual void LoadPlayer()
    {
        if (ghostCtrl.playerControler == null)
        {
            ghostCtrl.playerControler = Transform.FindObjectOfType<PlayerControler>();
        }
    }

    private void ChasePlayer()
    {
        Vector2 direction = ghostCtrl.playerControler.transform.position - transform.parent.position;
        if (direction.x < 0) // Player is on the left side of Ghost
        {
            transform.parent.localScale = new Vector3(-scale, scale, scale); // Flip the Ghost to face left
        }
        else // Player is on the right side of Ghost
        {
            transform.parent.localScale = new Vector3(scale, scale, scale); // Flip the Ghost to face right
        }

        transform.parent.position = Vector2.MoveTowards(transform.parent.position, ghostCtrl.playerControler.transform.position, Time.deltaTime * moveSpeed);
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
                transform.parent.position += (Vector3)direction.normalized * moveSpeed * Time.deltaTime;
            }
            if(targetPosition.x < transform.parent.position.x) transform.parent.localScale=new Vector3(-scale, scale, scale);
            else if (targetPosition.x > transform.parent.position.x) transform.parent.localScale = new Vector3(scale, scale, scale);
        }
    }
    
}