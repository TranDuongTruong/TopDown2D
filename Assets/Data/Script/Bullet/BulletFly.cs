using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : SaiMonoBehaviour
{
    public float flySpeed = 1;
    public Transform target;
    
   
    [SerializeField] BulletControler bulletCtrl;
    [Header("Electric")]
    private Vector2 randomDirection;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        bulletCtrl = transform.parent.GetComponent<BulletControler>();
    }
    protected override void Awake()
    {
        base.Awake();
        if (bulletCtrl.typeOfBullet == "Electric") randomDirection = Random.insideUnitCircle.normalized;

    }
    protected override void OnEnable()
    {
        base.OnEnable();
        if (bulletCtrl.typeOfBullet == "Electric") randomDirection = Random.insideUnitCircle.normalized;
    } 
   
    private void Update()
    {
        if (bulletCtrl.typeOfBullet == "Bullet") BulletFlying();
        else if (bulletCtrl.typeOfBullet == "Rocket") RocketFlying();
        else if (bulletCtrl.typeOfBullet == "Electric") ElectricFlying();
    }
    private void ElectricFlying()
    {
        Vector3 newPosition = transform.parent.position + new Vector3(randomDirection.x, randomDirection.y, 0f) * flySpeed * Time.deltaTime;
        transform.parent.position = newPosition;
    }
    private void BulletFlying()
    {
        if (target == null || target.gameObject.activeSelf == false)
        {
            bulletCtrl.Despawn.DespawnObject();
            return;
        }else
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, target.transform.position, Time.deltaTime * flySpeed);
    }
    private void RocketFlying()
    {
        
       
        if (target == null||target.gameObject.activeSelf==false)
        {
            bulletCtrl.Despawn.DespawnObject();
            return;
        }else    
        {
            Vector3 direction = target.position - transform.parent.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, target.transform.position, Time.deltaTime * flySpeed);

        }





    }

    /* private void RocketFlying()
     {
         if (isCompleteRotation&& moveToTarget)
         {
             model.rotation=Quaternion.Euler(0,0,180); isCompleteRotation=false;
         }
         if (target != null)
         {
             Vector3 direction = target.position - transform.parent.position;
             float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
             transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
         }

         elapsedTime += Time.deltaTime;
         if (elapsedTime > 1) loopsCompleted++;

         if (loopsCompleted < numLoopsBeforeTargeting)
         {

             float xOffset = Mathf.Cos(elapsedTime * rotationSpeed) * 3f;
             float yOffset = Mathf.Sin(elapsedTime * rotationSpeed) * 3f;

             Vector3 nextPosition = initialPosition + new Vector3(xOffset, yOffset, 0f);
             transform.parent.position = Vector3.MoveTowards(transform.parent.position, nextPosition, flySpeed * Time.deltaTime);


             Vector3 moveDirection = (nextPosition - transform.parent.position).normalized;


             float moveAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
             transform.parent.rotation = Quaternion.Euler(0f, 0f, moveAngle - 90f); // -90 ?? xoay ?úng h??ng trong môi tr??ng 2D


         }
         else if (target != null)
         {
             if (!moveToTarget&&isCompleteRotation)
             {
                 moveToTarget = true;
                 isCompleteRotation = true;
             }

             Vector3 direction = target.position - transform.parent.position;
             float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
             Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

             transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, targetRotation, rotationSpeed * Time.deltaTime);



             transform.parent.position = Vector2.MoveTowards(transform.parent.position, target.transform.position, Time.deltaTime * flySpeed);
         }
     }*/
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void SetSpeed(float speed)
    {
        this.flySpeed = speed;
    }
}
