using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyModelCtrl : SaiMonoBehaviour
{
    [SerializeField] public List<GameObject> models;
    [SerializeField] public GhostCtrl ghostCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModels();
        ghostCtrl = transform.parent.GetComponent<GhostCtrl>();
    }
    public void LoadModels()
    {
        if (models.Count > 0) return;
        Transform[] points = transform.GetComponentsInChildren<Transform>();

        foreach (Transform t in points)
        {
            if(t==this.transform) continue;
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
            } else model.SetActive(false);
        }
    }
}
