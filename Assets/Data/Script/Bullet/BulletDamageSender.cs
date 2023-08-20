using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : SaiMonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;

    [SerializeField] BulletControler bulletCtrl;
    [SerializeField] public float damage = 1;
    public FXSpawner fxSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadFxSpawner();
        bulletCtrl = transform.parent.GetComponent<BulletControler>();
    }
    protected virtual void LoadFxSpawner()
    {
        if (fxSpawner != null) return;
        fxSpawner = Transform.FindObjectOfType<FXSpawner>();
    }
    private void Update()
    {
        if (enemyCtrl == null) return;
        enemyCtrl.EnemyDamageReciver.TakeDamage(damage);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamageReciver"))
        {

            enemyCtrl = collision.transform.parent.GetComponent<EnemyCtrl>();
            if (enemyCtrl != null) 
            enemyCtrl.EnemyDamageReciver.TakeDamage(damage);
            
           CreateFXEffect(collision);
            bulletCtrl.Despawn.DespawnObject();
            // fileControler.FileDespawn.DespawnObject();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            // CreateFXEffect(collision);
            bulletCtrl.Despawn.DespawnObject();
          
        }
    }

    private void CreateFXEffect(Collider2D collision)
    {
        Transform pfDamagepp = fxSpawner.Spawn("pfDamagePopup", collision.transform.position, Quaternion.identity);
        pfDamagepp.gameObject.SetActive(true);
        pfDamagepp.localScale = new Vector3(2, 2, 2);
        pfDamagePopup pfDamage = pfDamagepp.GetComponent<pfDamagePopup>();

        if (pfDamage != null) pfDamage.SetValue((int)damage);
        if (bulletCtrl.typeOfBullet == "Rocket")
        {
            Transform exploslion = fxSpawner.Spawn("ExplosionEffect", collision.transform.position, Quaternion.identity);
            exploslion.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamageReciver"))
        {

            enemyCtrl = null;
        }
    }
}
