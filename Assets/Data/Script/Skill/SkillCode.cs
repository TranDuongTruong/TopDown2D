using System;
using UnityEngine;

public enum SkillCode
{
    NoSkill=0,
    Laser=1,
    Sipirt=2,
    Rocket=3,
    FireFile=4,
    IceFile=5,
    PosionFile=6,
    Electric=7,
    Ball=8,
}

public class SkillCodeParser
{
    public static SkillCode FromString(string itemName)
    {
        try
        {
            return (SkillCode)System.Enum.Parse(typeof(SkillCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return SkillCode.NoSkill;
        }
    }
}
