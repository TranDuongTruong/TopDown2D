using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCtrl : SaiMonoBehaviour
{
    [SerializeField] public int level = 1;
    [SerializeField] public PlayerControler playerControler;
    [SerializeField] public bool isActive = false;

    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (playerControler == null)
        {
            playerControler = Transform.FindObjectOfType<PlayerControler>();
        }
    }
}
