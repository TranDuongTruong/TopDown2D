using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SowrdAttack : SaiMonoBehaviour
{
    public float damage = 1f;
    public BoxCollider2D collider2D;
    public PlayerControler playerControler;
    public SwordEffectSpawner effectSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        effectSpawner=Transform.FindObjectOfType<SwordEffectSpawner>();
        playerControler=transform.parent.GetComponent<PlayerControler>();
    }
    public enum AttackDirection { 
        left,
        right,
        up,
        down
    }
    Vector2 rightAttackOffset;
   
    private void Start()
    {
     collider2D = GetComponent<BoxCollider2D>();
        rightAttackOffset = transform.position;
        AttackStop();
    }
    public void AttackRight()
    {
        isAttacking = true;
      //  sowrdCollider.enabled = true;
        transform.position = new Vector3((transform.parent.position.x - .15f), transform.parent.position.y - 0.04f);
         transform.localScale = new Vector3(-1, 1, 1); 
        collider2D.size = new Vector2(0.1362805f, 0.08146304f);
    }

    public void AttackLeft()
    {
        isAttacking = true;
       // sowrdCollider.enabled = true;
        transform.position = new Vector3((transform.parent.position.x + .15f), transform.parent.position.y - 0.04f);
        transform.localScale=new Vector3(1,1, 1); collider2D.size = new Vector2(0.1362805f, 0.08146304f);
       
    }
    public void AttackDown()
    {
        isAttacking = true;
      //  sowrdCollider.enabled = true;
        transform.position = new Vector3((transform.parent.position.x), transform.parent.position.y-0.09f);
        transform.localScale = new Vector3(1, 1, 1); collider2D.size = new Vector2(0.1362805f, 0.08146304f);
    }
    public void AttackUp()
    {
        isAttacking = true;
      //  sowrdCollider.enabled = true;
        transform.position = new Vector3((transform.parent.position.x ), transform.parent.position.y + 0.09f);
     //   Debug.Log("UAaaa"); 
        transform.localScale = new Vector3(1, 1, 1);
        collider2D.size = new Vector2(0.1362805f, 0.08146304f);
    }
    public void AttackStop()
    {
        isAttacking = false;
        // sowrdCollider.enabled = false;
        collider2D.size = new Vector2(0.01f, 0.01f);
        collider2D.offset = Vector3.zero;
        transform.position = new Vector3((transform.parent.position.x ), transform.parent.position.y );

       
      //  Debug.Log("Aaaa");
    }

   public void AttackEffect(string effectName)
    {
        Vector2 pos=new Vector2((transform.parent.position.x), transform.parent.position.y);
        Transform newEffect=effectSpawner.Spawn(effectName, pos, Quaternion.identity);
        newEffect.gameObject.SetActive(true);
        FileControler fileControler=newEffect.GetComponent<FileControler>();

        if (fileControler != null)
        {
            if (effectName == effectSpawner.effectHorizontal)
            {
                if (playerControler.spriteRenderer.flipX)
                {
                    fileControler.fileFly.SetDirection(new Vector3(-1, 0, 0));
                  //  fileControler.spriteRenderer.flipX = true;
                    fileControler.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    fileControler.fileFly.SetDirection(new Vector3(1, 0, 0));
                  //  fileControler.spriteRenderer.flipX = false;
                    fileControler.transform.localScale = new Vector3(1, 1, 1);
                }
            } else if(effectName== effectSpawner.effectTop)
            {
                fileControler.fileFly.SetDirection(new Vector3(0, 1, 0));
            }
            else if (effectName == effectSpawner.effectDown)
            {
                fileControler.fileFly.SetDirection(new Vector3(0, -1, 0));
            } else if (effectName == effectSpawner.effectDownLeft)
            {
                //newEffect.rotation=new Quaternion(0, 0, -135, 0);
               // newEffect.rotation = Quaternion.Euler(new Vector3(0, 0, -135));
                fileControler.fileFly.SetDirection(new Vector3(-1, -1, 0));
            }
            else if (effectName == effectSpawner.effectDownRight)
            {
             //   newEffect.rotation = new Quaternion(0, 0, -45, 0);
               // newEffect.rotation = Quaternion.Euler(new Vector3(0, 0, -45));
                fileControler.fileFly.SetDirection(new Vector3(1, -1, 0));
            }
            else if (effectName == effectSpawner.effectTopLeft)
            {
               // newEffect.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
                fileControler.fileFly.SetDirection(new Vector3(-1, 1, 0));
            }
            else if (effectName == effectSpawner.effectTopRight)
            {
                //newEffect.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
                fileControler.fileFly.SetDirection(new Vector3(1, 1, 0));
            }
        }

    }
    
    public bool isAttacking=false;
    public EnemyDamageReciver enemy1 = null;
    private void Update()
    {
        if (isAttacking)
        {
            
            if(enemy1 != null)
            {
                
                enemy1.TakeDamage(damage*Time.deltaTime);
              //  enemy1.Health -= damage*Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyDamageReciver enemy = collision.GetComponent<EnemyDamageReciver>();  
            enemy1 = enemy;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {          
            enemy1 = null;
        }
    }
}
