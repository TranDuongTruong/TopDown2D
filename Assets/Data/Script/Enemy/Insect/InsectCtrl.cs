using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectCtrl : EnemyCtrl
{
    

  //  [SerializeField] public float distanceToPlayer = 0;
    [SerializeField] protected InsectMovement  insectMovement;
    public InsectMovement InsectMovement => insectMovement;



    protected override void OnEnable()
    {
        insectMovement.RandomSpeed();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
         LoadMovement();

    }
    private void Update()
    {
        if (playerControler != null)
        {
            Vector3 direction = playerControler.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (!canMove)
        {
            return;
        }
        distanceToPlayer = Vector2.Distance(transform.position, playerControler.transform.position);
    }
  
    protected virtual void LoadMovement()
    {
        if (insectMovement == null)
        {
            insectMovement = transform.GetComponentInChildren<InsectMovement>();
        }
    }
}
