using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(CapsuleCollider2D))]
public abstract class DamageReceiver : SaiMonoBehaviour
{
    [Header("Damage Receiver")]
   // [SerializeField] protected CapsuleCollider2D capCollider;
    [SerializeField] protected float hp = 1;
    public float HP => hp;
    [SerializeField] protected float hpMax = 2;
    public float HPMax => hpMax;
    [SerializeField] protected bool isDead = false;
    public bool IsDeads => isDead;
    

    protected override void OnEnable()
    {
        this.Reborn();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
     //   this.LoadCollider();
    }

    /*protected virtual void LoadCollider()
    {
        if (this.capCollider != null) return;
        this.capCollider = GetComponent<CapsuleCollider2D>();
        //this.capCollider.isTrigger = true;
       
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }*/
    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
    }

    public virtual void Add(float add)
    {
        if (this.isDead) return;

        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(float deduct)
    {
        if (this.isDead) return;

        this.hp -= deduct;
        if (this.hp > hpMax) this.hp = hpMax;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}
