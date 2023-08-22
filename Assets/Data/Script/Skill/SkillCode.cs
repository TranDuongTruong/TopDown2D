using System;
using UnityEngine;

public enum SkillCode
{
    NoSkill=0,
    Laser,
    Sipirt,
    Rocket,
    Fire,
    Ice,
    Posion,
    Electric,
    Ball,
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
