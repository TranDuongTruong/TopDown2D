using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSystem : SaiMonoBehaviour
{
    [SerializeField] List<BossCtrl> bossCtrlList = new List<BossCtrl>();
  public  List<BossCtrl> BossCtrls=> bossCtrlList;
    public int numOfBoss = 0;
    public int num = 0;

   public bool isDead=false;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadBosses();
 numOfBoss=bossCtrlList.Count;
    }
    protected virtual void LoadBosses()
    {
        if (bossCtrlList.Count > 0) return;
        BossCtrl[] bosses = transform.GetComponentsInChildren<BossCtrl>();
        foreach (BossCtrl b in bosses)
        {
            bossCtrlList.Add(b);
        }
       
    }
    private void Update()
    {
        foreach (BossCtrl b in bossCtrlList)
        {
            if (b.gameObject.activeSelf) num++;
        }
        numOfBoss = num;
        num= 0;
        isDead = CheckAllBoss();
    }
    private bool CheckAllBoss()
    {
        foreach (BossCtrl b in bossCtrlList)
        {
            if (b.gameObject.activeSelf) return false;
        }
        return true;
    }
}
