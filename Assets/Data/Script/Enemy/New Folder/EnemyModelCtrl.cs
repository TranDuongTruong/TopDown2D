using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelCtrl : SaiMonoBehaviour
{
    [SerializeField] public List<GameObject> models;
    [SerializeField] public GameObject currentModels;
    [SerializeField] public EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModels();
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
    public void LoadModels()
    {
        if (models.Count > 0) return;
        Transform[] points = transform.GetComponentsInChildren<Transform>();

        foreach (Transform t in points)
        {
            if(t==this.transform|| t.name == "DamageSender") continue;
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
            
        }
        models[0].SetActive(true);
    }
    public void ChangeModel(string nameOfModel)
    {
        foreach(GameObject model in models)
        {
            if (model.name.Equals(nameOfModel))
            {
                model.SetActive(true);
                currentModels=model;
            } else model.SetActive(false);
        }
    }
    private void Update()
    {
       // currentModels.transform.LookAt(enemyCtrl.PlayerControler.transform);
    }
}
