using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SkillUICtrl : SaiMonoBehaviour
{
    [SerializeField] public Image background;
    [SerializeField] public TextMeshProUGUI content;
    [SerializeField] public Button button;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadBG(); LoadContentAndButton();

    }
    protected virtual void LoadBG()
    {
        Image []images= transform.GetComponentsInChildren<Image>();
        foreach (Image image in images)
        {
            if(image.name=="BackGround") background=image;
            break;
        }
    }
    protected virtual void LoadContentAndButton()
    {
        TextMeshProUGUI[] contents = transform.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (TextMeshProUGUI content in contents)
        {
            if (content.name == "Content") this.content = content;
            break;
        }
        button=this.content.transform.parent.GetComponent<Button>();
    }
    public void SetBGAndContent(string content, Image image)
    {
        this.content.text = content;
        this.background.sprite = image.sprite;
        this.background.color=Color.white;
    }
}
