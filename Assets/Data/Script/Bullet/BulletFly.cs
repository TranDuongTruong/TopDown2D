using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : SaiMonoBehaviour
{
    public float moveSpeed = 1;
    public Transform target;
    [SerializeField] BulletControler bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        bulletCtrl = transform.parent.GetComponent<BulletControler>();
    }
    private void Update()
    {
        if (target == null)
        {
            bulletCtrl.Despawn.DespawnObject();
            return;
        }
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, target.transform.position, Time.deltaTime * moveSpeed);

    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void SetSpeed(float speed)
    {
        this.moveSpeed = speed;
    }
}
