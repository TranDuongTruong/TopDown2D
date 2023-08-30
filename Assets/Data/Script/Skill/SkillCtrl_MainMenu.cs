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
        if(avatar==null)    
        avatar = GetComponent<Image>();
    }
    public void ActiveSkill()
    {
        isActive = true;
        avatar.color = Color.white;

      //  Debug.LogError("iiiiiaaa" + this.skillCode.ToString());
    }
    public void InActiveSkill()
    {
        isActive = false;
        avatar.color = Color.black;
       // Debug.LogError("aaa" + this.skillCode.ToString());

    }
}
