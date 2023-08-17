using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectOfFile : SaiMonoBehaviour
{
    [SerializeField] FileControler fileControler;
    public FXSpawner fxSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadFxSpawner();
        fileControler = transform.parent.GetComponent<FileControler>();
    }
    protected virtual void LoadFxSpawner()
    {
        if (fxSpawner != null) return;
        fxSpawner = Transform.FindObjectOfType<FXSpawner>();
    }
    public void CreateFileEffect(EnemyCtrl enemyCtrl, float damage)
    {
      if(enemyCtrl == null) return;
        
        enemyCtrl.PauseObject(3);

        if (SwordEffectSpawner.Instance.sprite.name == "Normal")
        {
            enemyCtrl.EnemyDamageReciver.TakeDamage(damage);
        }

        Transform effect = fxSpawner.Spawn(SwordEffectSpawner.Instance.sprite.name, enemyCtrl.transform.position, Quaternion.identity);
        effect.gameObject.SetActive(true);
        effect.localScale = new Vector3(.5f, .5f, .5f);
        
    }
}