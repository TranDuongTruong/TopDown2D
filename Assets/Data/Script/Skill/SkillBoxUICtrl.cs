using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillBoxUICtrl : SaiMonoBehaviour
{
    [SerializeField] protected Image skillSprite;
    [SerializeField] protected Image cooldownSprite;
    [SerializeField] protected TextMeshProUGUI levelText;
    int level = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        skillSprite = GetComponent<Image>();

        Image [] images = skillSprite.GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if (image != skillSprite)
            {
                cooldownSprite = image;
                cooldownSprite.gameObject.SetActive(false);
                break;
            }
        }
        levelText=transform.GetComponentInChildren<TextMeshProUGUI>();
        levelText.gameObject.SetActive(false);
       
    }
    public void SetSkill(Image image)
    {
        level++;
        skillSprite.sprite = image.sprite;
        skillSprite.color=Color.white;
        levelText.gameObject.SetActive(true) ;
        levelText.text = level.ToString();
    }
    public bool CheckImage(Image image)
    {
        if (skillSprite.sprite == image.sprite) return true;
        return false;
    }
    public void UpgradeSkill()
    {
        level++;
        levelText.text =level.ToString() ;
    }
}
