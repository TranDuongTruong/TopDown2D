using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCtrl : Spawner
{
    [SerializeField] public float damage = 1;
    [SerializeField] public float cooldown = 1;
    [SerializeField] public int count = 1;
    [SerializeField] public int level = 1;
    [SerializeField] public PointSystem pointSystem;
    [SerializeField] public PlayerControler playerControler;
    [SerializeField] public Transform posForPlayer;
    [SerializeField] public List< Transform > currentSkill;
    public bool isActive = false;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPointSystem(); LoadPlayer();
    }
    
    protected virtual void LoadPlayer()
    {
        if (playerControler == null)
        {
            playerControler = Transform.FindObjectOfType<PlayerControler>();
        }
    }
    public bool aa=false;
    private void Update()
    {
      //  int i=0;
      //  Debug.Log(pointSystem.Points[level - 1].Waypoints[i].localPosition.x +"/"+ pointSystem.Points[level - 1].Waypoints[i].localPosition.y + "/" + pointSystem.Points[level - 1].Waypoints[i].localPosition.z);
        if (aa)
        {
            UpgradeLevel();aa = false;
        }
        posForPlayer.localPosition = new Vector3(0, 0, 0);
    }
    protected virtual void LoadPointSystem()
    {
        if (pointSystem != null) return;
        pointSystem=transform.GetComponentInChildren<PointSystem>();
    }
   public void UpgradeLevel()
    {
        
        if (level == 1)
        {
            ReciveSkill(level);
           
            return;
        }
        RemoveSkill();
        damage *= 2;
        cooldown -= .2f;
        count++;
        ReciveSkill(level);
        
    }
    public void ReciveSkill(int level)
    {
         
        for(int i = 0; i < count; i++)
        {
            Transform newSkill = Spawn(prefabs[level - 1], pointSystem.Points[level - 1].Waypoints[i].position,Quaternion.identity);
            newSkill.gameObject.SetActive(true);
            newSkill.transform.parent = posForPlayer;
           newSkill.transform.localPosition =new Vector3( pointSystem.Points[level - 1].Waypoints[i].localPosition.x, pointSystem.Points[level - 1].Waypoints[i].localPosition.y, pointSystem.Points[level - 1].Waypoints[i].localPosition.z);
            currentSkill.Add(newSkill);
        }
       posForPlayer.parent = playerControler.transform;
        isActive = true;
       

       this.level++;
    }
    public void RemoveSkill()
    {
        for(int i=0;i<currentSkill.Count;i++)   
        {
           Transform empty = currentSkill[i];
            currentSkill.Remove(currentSkill[i]);
            i--;
            
             Destroy(empty.gameObject);
            
        }
        posForPlayer.parent = transform;
    }

}
