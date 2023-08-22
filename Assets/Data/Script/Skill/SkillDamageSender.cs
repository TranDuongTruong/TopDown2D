using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDamageSender : SaiMonoBehaviour
{
    [SerializeField] EnemyCtrl enemyCtrl;

    [SerializeField] RotationSkil shootByLaser;
 
    public FXSpawner fxSpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadFxSpawner();
        shootByLaser = transform.parent.parent.GetComponent<RotationSkil>();
    }
    protected virtual void LoadFxSpawner()
    {
        if (fxSpawner != null) return;
        fxSpawner = Transform.FindObjectOfType<FXSpawner>();
    }
    private void Update()
    {
        if (enemyCtrl == null||enemyCtrl.gameObject.activeSelf==false) return;
        enemyCtrl.EnemyDamageReciver.TakeDamage(shootByLaser.damage);

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
            //shootByLaser.FileDespawn.DespawnObject();
        }
    }

    private void CreateFXEffect(Collider2D collision)
    {
        Transform pfDamagepp = fxSpawner.Spawn("pfDamagePopup", collision.transform.position, Quaternion.identity);
        pfDamagepp.gameObject.SetActive(true);
        pfDamagepp.localScale = new Vector3(2, 2, 2);
        pfDamagePopup pfDamage = pfDamagepp.GetComponent<pfDamagePopup>();

        if (pfDamage != null) pfDamage.SetValue((int)shootByLaser.damage);
        /*Transform newFX = fxSpawner.Spawn("FX1", collision.transform.position, Quaternion.identity);

        newFX.gameObject.SetActive(true);*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyDamageReciver"))
        {

            enemyCtrl = null;
        }
    }
}
