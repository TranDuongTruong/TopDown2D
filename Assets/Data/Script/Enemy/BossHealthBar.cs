using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar :SaiMonoBehaviour
{
    [SerializeField] List<BossCtrl> bossCtrls ;
    [SerializeField] BossCtrl currentBoss ;
    [SerializeField] Slider hpBar ;
    
   

    protected override void LoadComponents()
    {
        base.LoadComponents();  LoadBossCtrls();LoadSlider();
    }
    
    protected virtual void LoadSlider()
    {
        if (hpBar != null ) return;
        Transform[] points = transform.GetComponentsInChildren<Transform>();
        foreach (Transform point in points)
        {
            if (point.name == "HealthBar") hpBar = point.GetComponent<Slider>();      
           
            

        }
        hpBar.gameObject.SetActive(false);
    }
    protected virtual void LoadBossCtrls()
    {
        if (bossCtrls.Count > 0) return;
        BossCtrl[] tmp=Transform.FindObjectsOfType<BossCtrl>();
        foreach (BossCtrl boss in tmp)
        {
            bossCtrls.Add(boss);
        }
    }
    public bool canActive=false;
    private void Update()
    {
        int i = 0;
        if (canActive)
        {
            if(!currentBoss.transform.gameObject.activeSelf )
            {
                canActive=false;
                currentBoss=null;
                hpBar.gameObject.SetActive(false);

            }else   hpBar.gameObject.SetActive(true); SetIntialValue();

        }
        else
        foreach(BossCtrl boss in bossCtrls)
        {
            if (boss.startAttack&&boss.gameObject.activeSelf)
            {
                currentBoss = boss;
                canActive = true;
                break;
            }
                i++;
        }

    }
    protected void SetIntialValue()
    {
     //   if (!currentBoss.gameObject.activeSelf) return;
        hpBar.maxValue = currentBoss.EnemyDamageReciver.HPMax;
        hpBar.value = currentBoss.EnemyDamageReciver.HP;
        
     
    }
}
