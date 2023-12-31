using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDamageSender : SaiMonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;

    [SerializeField]  FileControler fileControler;
    [SerializeField] public float damage = 1;
   public FXSpawner  fxSpawner; 

    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadFxSpawner();
        fileControler =transform.parent.GetComponent<FileControler>();
    }
    protected virtual void LoadFxSpawner()
    {
        if (fxSpawner != null) return;
        fxSpawner=Transform.FindObjectOfType<FXSpawner>();
    }
    private void Update()
    {
        if (enemyCtrl == null) return;
      //  enemyCtrl.EnemyDamageReciver.TakeDamage(damage) ;
        fileControler.EffectOfFile.CreateFileEffect(enemyCtrl,damage);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamageReciver"))
        {

            enemyCtrl = collision.transform.parent.GetComponent<EnemyCtrl>();
            CreateFXEffect(collision);
           // fileControler.FileDespawn.DespawnObject();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            CreateFXEffect(collision);
            fileControler.FileDespawn.DespawnObject();
        }
    }

    private void CreateFXEffect(Collider2D collision)
    {
        Transform pfDamagepp = fxSpawner.Spawn("pfDamagePopup", collision.transform.position, Quaternion.identity);
        pfDamagepp.gameObject.SetActive(true);
        pfDamagepp.localScale=new Vector3(2,2, 2);
        pfDamagePopup pfDamage=pfDamagepp.GetComponent<pfDamagePopup>();

        if (pfDamage != null) pfDamage.SetValue((int)damage);

        
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamageReciver"))
        {
            
            enemyCtrl = null;
        }
    }
}
