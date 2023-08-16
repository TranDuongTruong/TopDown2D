using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : SaiMonoBehaviour
{
    [SerializeField] public BulletFly bulletFly;
  
    [SerializeField] protected BulletDespawn despawn;
    [SerializeField] protected BulletDamageSender damageSender;
    public BulletDamageSender BulletDamageSender => damageSender;
    public BulletDespawn Despawn => despawn;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadFileFly();  LoadDespawn(); LoadFileDamageSender();
    }
    protected virtual void LoadFileFly()
    {
        if (bulletFly == null)
        {
            bulletFly = transform.GetComponentInChildren<BulletFly>();
        }
    }
 
    protected virtual void LoadDespawn()
    {
        if (despawn == null)
        {
            despawn = transform.GetComponentInChildren<BulletDespawn>();
        }
    }
    protected virtual void LoadFileDamageSender()
    {
        if (damageSender == null)
        {
            damageSender = transform.GetComponentInChildren<BulletDamageSender>();
        }
    }
}