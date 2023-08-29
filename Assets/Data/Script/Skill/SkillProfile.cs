using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillProfile", menuName = "SO/SkillProfile")]
public class SkillProfile : ScriptableObject
{
    public SkillCode skillCode = SkillCode.NoSkill;
    public SkillSO SkillSO = SkillSO.InActive;
    public string skillName = "no-name";



}
