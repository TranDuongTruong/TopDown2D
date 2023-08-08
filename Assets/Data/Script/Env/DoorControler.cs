using UnityEngine;

public class DoorControler : SaiMonoBehaviour
{
    [SerializeField] protected Transform point1, point2;
    [SerializeField] protected Transform model;
    [SerializeField] PlayerControler playerControler;
    public bool hadKey = true;
    public float range = 5f;
    public float moveSpeed = 2;
    public Transform currentPoint;
    
    public bool canOpen=false;
    [System.Obsolete]
    protected override void Awake()
    {
       


      
        currentPoint = point2;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
    
    }

    
    private void Update()
    {
       
        CheckPlayer();
        if (playerControler != null&& hadKey) canOpen = true;
        else canOpen = false;
            //  if (Vector2.Distance(model.position, point1.position) <= 0.01 || Vector2.Distance(model.position, point2.position) <= 0.01) return;
        if (canOpen)
        {
            currentPoint = point2;
            model.transform.position = Vector3.MoveTowards(model.transform.position, currentPoint.position, moveSpeed * Time.deltaTime);
           
        }
        else
        {
            currentPoint = point1;
            model.transform.position = Vector3.MoveTowards(model.transform.position, currentPoint.position, moveSpeed * Time.deltaTime);
            
        }
    }
    void CheckPlayer()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject p in player)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, p.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestEnemy = p;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
       
            playerControler = nearestEnemy.GetComponent<PlayerControler>();
        }
        else
        {
            playerControler = null;
        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);

    }
}
