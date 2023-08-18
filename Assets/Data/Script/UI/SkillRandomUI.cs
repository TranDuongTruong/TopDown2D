using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillRandomUI : SaiMonoBehaviour
{
   

    [SerializeField] public PlayerControler playerControler;
    [SerializeField] public SkillsSystemManager skillsSystem;
    [SerializeField] public List<SkillUICtrl> skillUICtrlList;
    [SerializeField] public TextMeshProUGUI skillPoint;
    [SerializeField] public List<SkillCtrl> sellectedSkills;
    [SerializeField] public Button closeButton;
    [SerializeField] public bool chose=false;

    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPlayer(); LoadSkillSystem(); LoadSkillUIList(); LoadSkillPoint(); LoadCloseButton();
    }

    protected virtual void LoadPlayer()
    {
        if (playerControler == null)
        {

            playerControler = Transform.FindObjectOfType<PlayerControler>();
        }
    }
    protected virtual void LoadSkillSystem()
    {
        if (skillsSystem == null)
        {

            skillsSystem = Transform.FindObjectOfType<SkillsSystemManager>();
        }
    }
    protected virtual void LoadSkillUIList()
    {
        if (skillUICtrlList.Count > 0) return;
        SkillUICtrl [] skillUICtrls=transform.GetComponentsInChildren<SkillUICtrl>();
        foreach(SkillUICtrl skillUICtrl in skillUICtrls)
        {
            skillUICtrlList.Add(skillUICtrl);
        }
    }
    protected virtual void LoadSkillPoint()
    {
        TextMeshProUGUI[] contents = transform.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI content in contents)
        {
            if (content.name == "SkillPoint") this.skillPoint = content;
            break;
        }
    }
    protected virtual void LoadCloseButton()
    {
        Button[] contents = transform.GetComponentsInChildren<Button>();
        foreach (Button content in contents)
        {
            if (content.name == "CloseButton") this.closeButton = content;
            break;
        }
    }
    private void Update()
    {

        closeButton.onClick.AddListener(CloseObj);
        skillPoint.text=playerControler.PlayerStatus.skillPoint.ToString();
        if (chose)
        {
            sellectedSkills = skillsSystem.GetThreeRandomUnmaxedSkills();
            for(int i = 0; i < 3; i++)
            {
                skillUICtrlList[i].SetBGAndContent(sellectedSkills[i].content.text, sellectedSkills[i].avatar);
            }
            chose = false;  
           
        }
        skillUICtrlList[0].button.onClick.AddListener(() => ChoosingSkill(0));
        skillUICtrlList[1].button.onClick.AddListener(() => ChoosingSkill(1));
        skillUICtrlList[2].button.onClick.AddListener(() => ChoosingSkill(2));
        
        
    }
    protected virtual void ChoosingSkill(int i)
    {
        if (playerControler.PlayerStatus.skillPoint == 0) return;
        playerControler.PlayerStatus.skillPoint--;
        skillsSystem.SelectSkill(sellectedSkills[i].name);
        chose = true;
    }
    protected virtual void CloseObj()
    {
        chose=false;
        transform.gameObject.SetActive(false);
    }

}