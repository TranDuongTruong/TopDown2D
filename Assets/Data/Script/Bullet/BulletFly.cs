using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : SaiMonoBehaviour
{
    public float flySpeed = 1;
    public Transform target;
    public string typeOfBullet = "Bullet";
    [SerializeField] BulletControler bulletCtrl;
    [Header("Rocket")]
    public float rotationSpeed = 360f;
    public Vector3 initialPosition;
    public float elapsedTime = 0f;
    public int loopsCompleted = 0;
    public int numLoopsBeforeTargeting = 1;
   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        bulletCtrl = transform.parent.GetComponent<BulletControler>();
    }
    protected override void Awake()
    {
        base.Awake();
        initialPosition = transform.position;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        initialPosition = transform.position; loopsCompleted = 0;
    }
    private void Update()
    {
        if(typeOfBullet=="Bullet") BulletFlying();
       else if (typeOfBullet == "Rocket") RocketFlying();
        
    }

    private void BulletFlying()
    {
        if (target == null)
        {
            bulletCtrl.Despawn.DespawnObject();
            return;
        }
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, target.transform.position, Time.deltaTime * flySpeed);
    }
 /*   private void RocketFlying()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.parent.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        elapsedTime += Time.deltaTime;

        // T�nh h??ng bay v�ng v�ng b?ng c�ch s? d?ng h�m sin v� cos
        float xOffset = Mathf.Cos(elapsedTime * rotationSpeed) * 1.5f;
        float yOffset = Mathf.Sin(elapsedTime * rotationSpeed) * 1.5f;

        Vector3 nextPosition = initialPosition + new Vector3(xOffset, yOffset, 0f);
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, nextPosition, flySpeed * Time.deltaTime);

        if (target != null)
        {
            // T�nh h??ng bay v�o m?c ti�u
            Vector3 direction = target.position - transform.parent.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

    }*/
    private void RocketFlying()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.parent.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        elapsedTime += Time.deltaTime;
        elapsedTime += Time.deltaTime;

        // T�nh s? v�ng quay ?� ho�n th�nh
        loopsCompleted = Mathf.FloorToInt(elapsedTime * (rotationSpeed / 360f));

        // T�nh s? v�ng quay ?� ho�n th�nh
        //loopsCompleted = Mathf.FloorToInt(elapsedTime * (rotationSpeed / 360f));

        if (loopsCompleted < numLoopsBeforeTargeting)
        {
            // T�nh h??ng bay v�ng v�ng b?ng c�ch s? d?ng h�m sin v� cos
            float xOffset = Mathf.Cos(elapsedTime * rotationSpeed) * 1.5f;
            float yOffset = Mathf.Sin(elapsedTime * rotationSpeed) * 1.5f;

            Vector3 nextPosition = initialPosition + new Vector3(xOffset, yOffset, 0f);
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, nextPosition, flySpeed * Time.deltaTime);
            
            
            Vector3 moveDirection = (nextPosition - transform.parent.position).normalized;

            // T�nh g�c quay theo h??ng di chuy?n (trong m�i tr??ng 2D)
            float moveAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, moveAngle - 90f); // -90 ?? xoay ?�ng h??ng trong m�i tr??ng 2D

            Debug.Log(transform.parent.rotation.z);
           // transform.parent.rotation = Quaternion.Euler(moveRotation.x, moveRotation.y, moveRotation.z);

        }
        else if (target != null)
        {
            // T�nh h??ng bay v�o m?c ti�u
            Vector3 direction = target.position - transform.parent.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.parent.rotation = Quaternion.Slerp(transform.parent.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Bay th?ng v�o m?c ti�u
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, target.transform.position, Time.deltaTime * flySpeed);
        }
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    public void SetSpeed(float speed)
    {
        this.flySpeed = speed;
    }
}
