using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectMovement : SaiMonoBehaviour
{

    [SerializeField] InsectCtrl insectCtrl;


    [SerializeField] float currentSpeed = 1;
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float moveSpeedMax = 1;
    [SerializeField] float moveSpeedMin = 5;
    [SerializeField] float speed = 1;
    [SerializeField] float scale = .5f;
    [SerializeField] List<Transform> waypoints;
    [SerializeField] PointCtrl waypointCtrl;
    private int currentWaypointIndex = 0;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        insectCtrl = transform.parent.GetComponent<InsectCtrl>();
       
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
      //  insectCtrl.EnemyModelCtrl.currentModels.transform.LookAt(insectCtrl.playerControler.transform.position);
        if (!insectCtrl.canMove) return;

        if (insectCtrl.DistanceToPlayer <= 1.5f && !insectCtrl.EnemyAttack.isAttacking || insectCtrl.EnemyDamageReciver.takingDamage)
        {
          
            insectCtrl.EnemyModelCtrl.ChangeModel("Run");
            if (insectCtrl.EnemyDamageReciver.takingDamage) currentSpeed = -2f;
            else currentSpeed = 1.25f;

            ChasePlayer();
            insectCtrl.EnemyDamageReciver.takingDamage = false;
        }
        else if (!insectCtrl.EnemyAttack.isAttacking)
        {
            insectCtrl.EnemyModelCtrl.ChangeModel("Run");
            currentSpeed = speed;
            ChasePlayer();
           
        }
    }

  

    private void ChasePlayer()
    {
        Vector2 direction = insectCtrl.PlayerControler.transform.position - transform.parent.position;
        if (direction.x < 0) // Player is on the left side of Ghost
        {
            transform.parent.localScale = new Vector3(scale, scale, scale); // Flip the Ghost to face left
        }
        else // Player is on the right side of Ghost
        {
            transform.parent.localScale = new Vector3(scale, scale, scale); // Flip the Ghost to face right
        }

        transform.parent.position = Vector2.MoveTowards(transform.parent.position, insectCtrl.PlayerControler.transform.position, Time.deltaTime * currentSpeed);
    }
    public void RandomSpeed()
    {
        speed = Random.Range(moveSpeedMin, moveSpeedMax);
    }
}
