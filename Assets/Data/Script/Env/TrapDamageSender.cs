using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamageSender : MonoBehaviour
{
    public float damage = 1f;
  
    public PlayerControler playerControler;
    private void Update()
    {
        if (playerControler == null) return;
        
           playerControler.DamageReciver.TakeDamage(damage);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerDamageReciver"))
        {
           
            playerControler =collision.transform.parent.GetComponent<PlayerControler>();
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
