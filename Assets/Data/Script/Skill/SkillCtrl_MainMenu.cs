using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCtrl_MainMenu : SaiMonoBehaviour
{
    [SerializeField] protected Image avatar;
    public SkillCode skillCode;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        avatar = GetComponent<Image>();
    }
    public void ActiveSkill(SkillCode skillCode)
    {
        if (skillCode == this.skillCode)
        {
            avatar.color = Color.white;
        }
    }
}
