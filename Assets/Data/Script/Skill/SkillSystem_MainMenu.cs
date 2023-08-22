using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSystem_MainMenu : SaiMonoBehaviour
{
    [SerializeField] public List<SkillCtrl_MainMenu> skillCtrl_Mains;
    [SerializeField] public Button researchCloseButton;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadSkill(); LoadnButton();
    }
    protected override void Awake()
    {
        base.Awake();
        researchCloseButton.onClick.AddListener(CloseResearch);
    }
    protected void CloseResearch()
    {
        transform.gameObject.SetActive(false);
    }
    protected virtual void LoadSkill()
    {
        SkillCtrl_MainMenu[] tmp=transform.GetComponentsInChildren<SkillCtrl_MainMenu>();
        foreach(SkillCtrl_MainMenu skillCtrl in tmp)
        {
            skillCtrl_Mains.Add(skillCtrl);
        }
    }
    protected virtual void LoadnButton()
    {
        Button[] contents = transform.GetComponentsInChildren<Button>();
        foreach (Button content in contents)
        {
            if (content.name == "CloseResearchButton") this.researchCloseButton = content;
            


        }
    }
}
