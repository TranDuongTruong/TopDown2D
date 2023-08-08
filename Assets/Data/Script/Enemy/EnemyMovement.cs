using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : SaiMonoBehaviour
{
    public List<Vector2> movePoint = new List<Vector2>();
    public bool canRun=false;
    [SerializeField] public int currentPoint=0;
    [SerializeField] public Rigidbody2D rb ;
    public float pushbackForce = 5f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMovePoint();
        rb =transform.parent. GetComponent<Rigidbody2D>();
    }

    public void LoadMovePoint()
    {
        if (movePoint.Count > 0) return;
        Transform[] points = transform.GetComponentsInChildren<Transform>();

        foreach (Transform t in points)
        {
            if (t != null &&t!=transform) movePoint.Add(t.position);
        }
    }
    private void Update()
    {

        if (canRun)
        {


            MoveToCurrentPoint();
        }
        else { rb.velocity = Vector2.zero; currentPoint = Random.Range(0, movePoint.Count); }

    }
    public void MoveToCurrentPoint()
    {
        

        Vector3 targetPosition = movePoint[currentPoint];
        Vector3 direction = targetPosition - transform.parent.position;
        float distance = direction.magnitude;

        if (distance > 0.05f)
        {
            direction.Normalize();
            rb.velocity = direction * .8f;
        }
        
       
    }
   
}

