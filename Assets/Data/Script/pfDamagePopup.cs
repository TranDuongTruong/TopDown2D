using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class pfDamagePopup : SaiMonoBehaviour
{
    [SerializeField] TextMeshPro text;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadText();
    }
    protected virtual void LoadText()
    {
        if (text != null) return;
        text=transform.GetComponent<TextMeshPro>();
    }
    public void SetValue(int damage)
    {
        text.text = damage.ToString();
    }
}
