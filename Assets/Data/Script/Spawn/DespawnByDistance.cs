using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 10f;
    [SerializeField] protected float distance = 0f;
 
    [SerializeField] public PlayerControler playerControler;
    protected override void LoadComponents()
    {
        LoadPlayer();
    }

  

    protected override bool CanDespawn()
    {
        distance = Vector2.Distance(transform.position, playerControler.transform.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }

    
   
    protected virtual void LoadPlayer()
    {
        if (playerControler == null)
        {
            playerControler = Transform.FindObjectOfType<PlayerControler>();
        }
    }
}
