using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportGateCtrl : SaiMonoBehaviour
{
    [SerializeField] public List<Transform> teleObjs;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadTelePos();
        
    }

    public void LoadTelePos()
    {
        if (teleObjs.Count > 0) return;
        Transform[] points = transform.GetComponentsInChildren<Transform>();

        foreach (Transform t in points)
        {
            if (t != null && t != transform && t.GetComponent<TeleportCtrl>()!=null) teleObjs.Add(t);
        }
    }
}
