using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCtrl : SaiMonoBehaviour
{
    [SerializeField] public TeleportGateCtrl teleportGateCtrl;
    [SerializeField] public Transform nextPos;
    public float timeToTele = 5f;
    public float currentTime = 0f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTeleportGateCtrl();

    }
    protected void LoadTeleportGateCtrl()
    {
        if (teleportGateCtrl != null) return;
        teleportGateCtrl=transform.parent.GetComponent<TeleportGateCtrl>();
    }
   
    [SerializeField] PlayerControler playerControler;
    public bool hadKey = true;
  
  
    public bool canOpen = false;
    public bool canNextTele = true;
    


    private void Update()
    {

       // CheckPlayer();
        if (CheckTimeToTeleport() && hadKey) canOpen = true;
        else canOpen = false;


        if (canOpen &&canNextTele)
        {
            if (nextPos != null )
            {
                playerControler.transform.position = new Vector2(nextPos.position.x, nextPos.position.y);

            }
            else
            {
                int index = 0;
                while (transform == teleportGateCtrl.teleObjs[index])
                    index = Random.Range(0, teleportGateCtrl.teleObjs.Count);

                playerControler.transform.position = new Vector2(teleportGateCtrl.teleObjs[index].position.x, teleportGateCtrl.teleObjs[index].position.y);
                //   playerControler.transform.position = nextPos.position;
            }
            canOpen = false;
            playerControler = null;
            canNextTele = false;
        }
        
    }
    public float distanceToPlayer;
    
    bool CheckTimeToTeleport()
    {
        if (playerControler == null)
        {
            currentTime = 0;
            return false;
        }
        currentTime+=Time.deltaTime;
        if(currentTime >= timeToTele){
            currentTime = 0;
            return true;
        } return false;
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
        
            playerControler=collision.transform.GetComponent<PlayerControler>();
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            playerControler = null;
        }
    }

  
}
