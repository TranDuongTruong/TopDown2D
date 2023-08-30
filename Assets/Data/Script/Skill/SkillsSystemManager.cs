using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsSystemManager : SaiMonoBehaviour
{
    private static SkillsSystemManager instance;
    public static SkillsSystemManager Instance => instance;
    [SerializeField] protected List<SkillCtrl> skillCtrlList = new List<SkillCtrl>();
    [SerializeField] protected int numOfSkillToRandom = 3;
    [SerializeField] protected ResearchSkillCtrl researchSkillCtrl;
    public bool reset=false;
    protected override void LoadComponents()
    {
        
        base.LoadComponents(); LoadSkillList();

    }
    protected override void Awake()
    {
        instance = this;
    }
    protected virtual void LoadSkillList()
    {
        if (skillCtrlList.Count < 0) return;
        SkillCtrl [] skillCtrls = GetComponentsInChildren<SkillCtrl>();
        foreach (SkillCtrl skillCtrl in skillCtrls)
        {
            skillCtrlList.Add(skillCtrl);
        }
    }
    private void Update()
    {
        if (reset)
        {
            foreach (SkillProfile skill in researchSkillCtrl.skillList)
            {
               
                
                    skill.SkillSO = SkillSO.InActive;
                
            }
            reset= false;
        }
    }

    protected List<SkillCtrl> GetRandomUnmaxedSkills()
    {
        List<SkillCtrl> unmaxedSkills = new List<SkillCtrl>();

        foreach (SkillCtrl skillCtrl in skillCtrlList)
        {
            if (skillCtrl.level < skillCtrl.levelMax)
            {
                unmaxedSkills.Add(skillCtrl);
            }
        }

        List<SkillCtrl> selectedSkills = new List<SkillCtrl>();
        int count = unmaxedSkills.Count;
        if (count <= numOfSkillToRandom)
        {
            selectedSkills = unmaxedSkills;
        }
        else
        {
            HashSet<int> selectedIndices = new HashSet<int>();
            while (selectedIndices.Count < numOfSkillToRandom)
            {
                int randomIndex = UnityEngine.Random.Range(0, count);
                if (!selectedIndices.Contains(randomIndex))
                {
                    selectedIndices.Add(randomIndex);
                    selectedSkills.Add(unmaxedSkills[randomIndex]);
                }
            }
        }

        return selectedSkills;
    }


    public List<SkillCtrl> GetThreeRandomUnmaxedSkills()
    {
        List<SkillCtrl> selectedSkills = GetRandomUnmaxedSkills();

        return selectedSkills;
    }
    public void SelectSkill(string name, SkillCode skillCode)
    {
        foreach(SkillCtrl skillCtrl in skillCtrlList)
        {
            if (skillCtrl.name == name)
            {
                skillCtrl.isActive = true;

            }
        }
        foreach(SkillProfile skill in researchSkillCtrl.skillList)
        {
            if (skill.skillCode ==skillCode)
            {
                skill.SkillSO = SkillSO.Acctive;
                Debug.Log(skill.name);
            }
            else Debug.Log("AA" + skill.name + "    " + skill.skillCode.ToString() + "      n: " + name);
        }
        
    }
}
