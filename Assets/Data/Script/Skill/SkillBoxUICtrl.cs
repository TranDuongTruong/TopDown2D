using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBoxUICtrl : SaiMonoBehaviour
{
    [SerializeField] protected Image skillSprite;
    [SerializeField] protected Image cooldownSprite;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        skillSprite = GetComponent<Image>();
    }
    public void SetSkill(Image image)
    {
        skillSprite.sprite = image.sprite;
        skillSprite.color=Color.white;
    }
}
