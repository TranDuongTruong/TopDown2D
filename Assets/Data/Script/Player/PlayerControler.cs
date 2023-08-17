using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : SaiMonoBehaviour
{
    public float maxPower = 100;
    public float power = 100;
    public bool isRunning=false;


    public float moveSpeed = 1f;
    public float collisionOffset = .05f;
    public ContactFilter2D movementFilter;
    public Animator animator;
    [SerializeField] public SpriteRenderer spriteRenderer;
    public Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    public SowrdAttack sowrdAttack;
    [SerializeField] PlayerDamageReciver damageReciver;
    public PlayerDamageReciver DamageReciver => damageReciver;
    [SerializeField] Inventory inventory;
    public Inventory Inventory => inventory;

    [SerializeField] PlayerStatus playerStatus;
    public PlayerStatus PlayerStatus => playerStatus;
    protected override void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPlayerDamageReciver(); LoadInventory(); LoadPlayerStatus();
    }
    protected void LoadPlayerDamageReciver()
    {
        if (damageReciver != null) return;
        damageReciver=transform.GetComponentInChildren<PlayerDamageReciver>();
    }
    protected void LoadInventory()
    {
        if (inventory != null) return;
        inventory = transform.GetComponentInChildren<Inventory>();
    }
    protected void LoadPlayerStatus()
    {
        if (playerStatus != null) return;
        playerStatus = transform.GetComponentInChildren<PlayerStatus>();
    }
    private void FixedUpdate()
    {
        Running();
        if (damageReciver.takeDamage)
        {
            animator.Play("Player_TakeDamage");
        }
        else
        {
            // Smoothly move the player based on movementInput
            rb.velocity = movementInput * moveSpeed;
        }
        if (movementInput!= Vector2.zero)
        {
            bool success=TryMove(movementInput);
            if (!success)
            {
                success=TryMove(new Vector2(movementInput.x,0));
                if (!success)
                {
                    success = TryMove(new Vector2(0,movementInput.y));
                }
               
            }
             animator.SetBool("isHorizontalMoving",success);
            if (movementInput.y < 0)
            {
                animator.SetBool("isMoveDown", true);
                animator.SetBool("isHorizontalMoving", false);
                animator.SetBool("isMoveUp", false);
            }
            else if (movementInput.y > 0)
            {
                animator.SetBool("isHorizontalMoving", false);
                animator.SetBool("isMoveDown", false);
                animator.SetBool("isMoveUp", true);
            }
            else
            {
                animator.SetBool("isMoveDown", false);
                animator.SetBool("isMoveUp", false);
            }
        }
        else
        {
            animator.SetBool("isHorizontalMoving", false);
            animator.SetBool("isMoveDown", false);
            animator.SetBool("isMoveUp", false);
        }
    /* else
        {
            animator.SetBool("isHorizontalMoving", false);
        }*/
        if (movementInput.x < 0)
        {
            spriteRenderer.flipX = true;
        } else if (movementInput.x > 0)
        {
            spriteRenderer.flipX=false;
        }

        if (damageReciver.takeDamage)
        {
            Color color = spriteRenderer.color;
            color.a -= 0.1f ;
            color=Color.black;
            spriteRenderer.color = color;
        }
        else
        {
            Color color = spriteRenderer.color;
            color.a = 1f; color = Color.white;
            spriteRenderer.color = color;
        }
    } 

    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
                         direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                        movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                        castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                        moveSpeed * Time.fixedDeltaTime + collisionOffset);
     
        if (count == 0)
        {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else return false;
    }

    void OnMove(InputValue movementValue)//duoc goi boi component player Input
    {
       
        movementInput=movementValue.Get<Vector2>();
    }
    void OnFire()
    {
        animator.SetTrigger("swordAttack");
        /*if (damageReciver.takeDamage)
        {
            animator.SetBool("takeDamage", true);

        }
        else animator.SetBool("takeDamage", false);*/


    }
    public void OnRun()
    {
        if (Keyboard.current.spaceKey.isPressed)
        {
            isRunning = true;
           
           
        }
        else
        {
            isRunning = false;
            
        }
        /* isRunning = true;
         moveSpeed = 2f;
         power -= 2*Time.fixedDeltaTime;



         if (context.started)
         {
             isRunning = true;
             moveSpeed = 2f;
             power -= Time.fixedDeltaTime;
         }
         if (context.canceled)
         {
             isRunning = false;
             moveSpeed = 1f;
         }*/
    }
    
    
    
    /*private void Update()
    {
        Running();
    }*/

    private void Running()
    {
        if (!isRunning)
        {
            moveSpeed = playerStatus.speed;
            if (power < playerStatus.maxPower)
            {
                power += Time.deltaTime;
            }
        }
        else if (power > 0 && isRunning)
        {
            moveSpeed = playerStatus.maxSpeed;
            power -= 10 * Time.deltaTime;
        }
        else moveSpeed = playerStatus.speed;
    }

    public void SwordAttack()
    {
       
        if (movementInput.x == 0&&movementInput.y==0)
        {
            if(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name== "Player_Attack1") sowrdAttack.AttackDown();
            else
            if (spriteRenderer.flipX) sowrdAttack.AttackRight();
            else if(!spriteRenderer.flipX) sowrdAttack.AttackLeft();
        } else        
        if (movementInput.x > 0)
        {
            sowrdAttack.AttackLeft();
        }
        else if(movementInput.x < 0)
        {
            sowrdAttack.AttackRight();
        } else if(movementInput.y < 0)
        {
            sowrdAttack.AttackDown();
        }
        else
        {
            sowrdAttack.AttackUp();
        }


    }
    public void StopAttack()
    {
        sowrdAttack.AttackStop();
    }
    public void TakeDamage()
    {
        animator.Play("Player_idle");
    }
    public void AttackEffectHorizontal()
    {
       if( !CrossEffect())  sowrdAttack.AttackEffect(SwordEffectSpawner.Instance.effectHorizontal);

    }

    private bool CrossEffect()
    {
        if (movementInput.y > 0 && movementInput.x > 0)
        {
            sowrdAttack.AttackEffect(SwordEffectSpawner.Instance.effectTopRight);
            return true;
        }
        else if (movementInput.y > 0 && movementInput.x < 0)
        {
            sowrdAttack.AttackEffect(SwordEffectSpawner.Instance.effectTopLeft); return true;
        }
        else if (movementInput.y < 0 && movementInput.x < 0)
        {
            sowrdAttack.AttackEffect(SwordEffectSpawner.Instance.effectDownLeft); return true;
        }
        else if (movementInput.y < 0 && movementInput.x > 0)
        {
            sowrdAttack.AttackEffect(SwordEffectSpawner.Instance.effectDownRight); return true;
        }

        return false;
    }

    public void AttackEffectTop()
    {
        if (!CrossEffect()) sowrdAttack.AttackEffect(SwordEffectSpawner.Instance.effectTop);
    }
    public void AttackEffectDown()
    {
        if (!CrossEffect()) sowrdAttack.AttackEffect(SwordEffectSpawner.Instance.effectDown);
    }
}
