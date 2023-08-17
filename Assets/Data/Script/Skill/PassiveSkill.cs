using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Spawner
{
  
    [SerializeField] public int count = 1;
    [SerializeField] public int level = 1;

    [SerializeField] public SkillCtrl skillCtrl;
    [SerializeField] public PointSystem pointSystem;
   
    [SerializeField] public Transform posForPlayer;
    [SerializeField] public List< Transform > currentSkill;
   
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPointSystem(); LoadSkillCtrl();

    }
    
    
    protected virtual void LoadSkillCtrl()
    {
        if (skillCtrl == null)
        {
            skillCtrl = transform.GetComponent<SkillCtrl>();
        }
    }

    private void Update()
    {
    
        if (skillCtrl.isActive)
        {
            UpgradeLevel(); skillCtrl.isActive = false;
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
        
        if (skillCtrl.level == 1)
        {
            ReciveSkill(skillCtrl.level);
           
            return;
        }
        RemoveSkill();
        
        count++;
        ReciveSkill(skillCtrl.level);
        
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
       posForPlayer.parent = skillCtrl.playerControler.transform;
       

        skillCtrl.level++;
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
