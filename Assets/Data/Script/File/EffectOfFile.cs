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
       

        
            enemyCtrl.EnemyDamageReciver.TakeDamage(damage);
            Transform effect = fxSpawner.Spawn(SwordEffectSpawner.Instance.sprite.name, enemyCtrl.transform.position, Quaternion.identity);
       /* if (fileControler.typeOfFile == "Ice")
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.iceOfFile,0.01f);
        }*/
        if (effect != null)
        {
            effect.gameObject.SetActive(true);
            effect.localScale = new Vector3(.5f, .5f, .5f);
        }
        
    }
}
