using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : SaiMonoBehaviour
{
    [SerializeField] public PlayerControler playerControler;
    [SerializeField] public CanvasCtrl canvasCtrl;
    [SerializeField] public float hp=100;
    [SerializeField] public float speed=5;
    [SerializeField] public float maxHp=100;
    [SerializeField] public float maxSpeed=10;
    [SerializeField] public float damage=20;
    [SerializeField] public float exp=0;
    [SerializeField] public float maxExp=50;   
    [SerializeField] public float level=0;
    [SerializeField] public float maxPower=100;
    [SerializeField] public float skillPoint=0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();

    }
    public void LoadPlayer()
    {
        if (playerControler != null) return;
        playerControler = transform.parent.GetComponent<PlayerControler>();
        canvasCtrl=Transform.FindObjectOfType<CanvasCtrl>();
    }
    private void Update()
    {
        UpgradeLevel();
    }
    public void UpgradeLevel()
    {
       if (exp >= maxExp)
        {
            level++;

            exp -=maxExp;

            maxExp *= 2;

            damage += damage / 2; 
            hp += maxHp / 2;
            maxHp += maxHp / 2;
            skillPoint++;
            canvasCtrl.activeRandomSkills = true;
        }
    }
    public void GetAbility(ItemStatus itemStatus)
    {
        
        this.damage+= itemStatus.damage;
        this.exp+= itemStatus.exp;
        this.speed += itemStatus.speed;
        this.maxSpeed += itemStatus.maxSpeed;

        playerControler.DamageReciver.IncreaseHP(itemStatus.hp, itemStatus.maxHp);
    }
}
