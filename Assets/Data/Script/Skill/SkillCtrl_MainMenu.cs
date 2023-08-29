using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCtrl_MainMenu : SaiMonoBehaviour
{
    [SerializeField] protected Image avatar;
    public SkillCode skillCode;
    public bool isActive=false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        avatar = GetComponent<Image>();
    }
    public void ActiveSkill(SkillCode skillCode)
    {
        isActive = true;
            avatar.color = Color.white;
        
    }
}
