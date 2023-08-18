using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillCtrl : SaiMonoBehaviour
{
    [SerializeField] public int level = 0;
    [SerializeField] public int levelMax = 3;

    [SerializeField] public PlayerControler playerControler;
    [SerializeField] public bool isActive = false;
    [SerializeField] public TextMeshPro content;
    [SerializeField] public Image avatar;

    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPlayer(); LoadAvatar(); LoadContent();
    }

    protected virtual void LoadPlayer()
    {
        if (playerControler == null)
        {
           
            playerControler = Transform.FindObjectOfType<PlayerControler>();
        }
    }
    protected virtual void LoadContent()
    {
        TextMeshPro[] contents = transform.GetComponentsInChildren<TextMeshPro>();
        foreach (TextMeshPro content in contents)
        {
            if (content.name == "Content") this.content = content;
            break;
        }
        content.gameObject.SetActive(false);
    }
    protected virtual void LoadAvatar()
    {
        Image[] contents = transform.GetComponentsInChildren<Image>();
        foreach (Image content in contents)
        {
            if (content.name == "Avatar") this.avatar = content;
            break;
        }
        avatar.gameObject.SetActive(false);
    }
}
