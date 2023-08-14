using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasCtrl : SaiMonoBehaviour
{
   [SerializeField] PlayerControler playerControler;
    [SerializeField] Slider hpBar, powerBar,expBar;
    [SerializeField] Text xpText, healthText;
    
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadPlayer(); LoadSlider(); SetIntialValue();
    }
    protected virtual void LoadPlayer()
    {
        if (playerControler != null) return;
        playerControler=Transform.FindObjectOfType<PlayerControler>();

    }
    protected virtual void LoadSlider()
    {
        if (hpBar != null&&powerBar!=null) return;
        Transform[] points = transform.GetComponentsInChildren<Transform>();
        foreach (Transform point in points)
        {
            if (point.name == "Health bar") hpBar = point.GetComponent<Slider>();
            if (point.name == "PowerBar") powerBar = point.GetComponent<Slider>();
            if (point.name == "XpBar") expBar = point.GetComponent<Slider>();
            if (point.name == "XpText") xpText = point.GetComponent<Text>();
            if (point.name == "HealthText") healthText = point.GetComponent<Text>();


        }
    }
    protected void SetIntialValue()
    {
        hpBar.maxValue = playerControler.DamageReciver.HPMax;
        hpBar.value = playerControler.DamageReciver.HP;
        expBar.value = playerControler.PlayerStatus.exp;
        expBar.maxValue = playerControler.PlayerStatus.maxHp;
        powerBar.maxValue = playerControler.PlayerStatus.maxPower;
        powerBar.value = playerControler.PlayerStatus.maxPower;
    }
    private void Update()
    {
        xpText.text=(expBar.value+"/"+expBar.maxValue);
        healthText.text=(hpBar.value+"/"+hpBar.maxValue);
        hpBar.value = playerControler.DamageReciver.HP;
        powerBar.value = playerControler.power;
        expBar.value = playerControler.PlayerStatus.exp;
        if (expBar.value > expBar.maxValue)
        {
            expBar.maxValue = playerControler.PlayerStatus.maxHp;
        }
    }
}
