using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageReciver : DamageReceiver
{
    [SerializeField] public PlayerControler playerControler;
    
    public bool takeDamage=false;
    protected override void OnDead()
    {
        throw new System.NotImplementedException();
    }
    public void IncreaseHP(float hp, float maxHp)
    {
        this.hp += hp;
        this.hpMax += maxHp;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
        
    }
    public void LoadPlayer()
    {
        if (playerControler != null) return;
        playerControler = transform.parent.GetComponent<PlayerControler>();
    }
    public void TakeDamage(float damage)
    {
        takeDamage= true;
        playerControler.animator.SetBool("tookDamage", true);
        this.Deduct(damage);
       

    }
   public float time=0;
    private void Update()
    {
        time+=Time.deltaTime;

        if (takeDamage&&time>=.05f)
        {
           // spriteRenderer.color = Color.Lerp(Color.red, Color.green, 1f);
            takeDamage = false;
            time = 0;
        }
        
    }


}
