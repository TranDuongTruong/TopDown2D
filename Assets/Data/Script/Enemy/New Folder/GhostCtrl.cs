using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCtrl : EnemyCtrl
{
    

  //  [SerializeField] public float distanceToPlayer = 0;
    [SerializeField] protected GhostMovement ghostMovement;
    public GhostMovement GhostMovement => ghostMovement;


    protected override void OnEnable()
    {
        ghostMovement.RandomSpeed();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
     
    }
    private void Update()
    {
        if (!canMove)
        {         
            return;
        }
        distanceToPlayer = Vector2.Distance(transform.position, playerControler.transform.position);
    }
   
}
