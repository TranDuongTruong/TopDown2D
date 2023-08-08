using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : SaiMonoBehaviour
{
    [SerializeField] PlayerControler playerControler;
  //  [SerializeField] EnemyModelCtrl models;

    [SerializeField] float damage = 100;


    protected override void LoadComponents()
    {
        base.LoadComponents();
     //   models = transform.parent.GetComponent<EnemyModelCtrl>();

    }
    private void Update()
    {
        if (playerControler == null) return;
        playerControler.DamageReciver.TakeDamage(damage);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDamageReciver"))
        {

            playerControler = collision.transform.parent.GetComponent<PlayerControler>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDamageReciver"))
        {
            playerControler = null;
        }
    }
    
}
