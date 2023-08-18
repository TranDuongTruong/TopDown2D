using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkill : SaiMonoBehaviour
{


    [SerializeField] public SkillCtrl skillCtrl;
    [SerializeField] public string effectName="Ice";
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSkillCtrl();
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
            
                if (skillCtrl.level >= skillCtrl.levelMax) return;
                skillCtrl.level++;
                skillCtrl.isActive = false;
                skillCtrl.playerControler.sowrdAttack.effectSpawner.SetTypeOfEffect(effectName);
            
           
            
        }
       
    }
}
