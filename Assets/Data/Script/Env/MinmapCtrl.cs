using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinmapCtrl : SaiMonoBehaviour
{
    [SerializeField] public GameObject minmapOpen, minmapClose;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        CloseMinimap();
    }
    public void OpenMinimap()
    {
        minmapOpen.SetActive(true);
        minmapClose.SetActive(false);

    }
    public void CloseMinimap()
    {
        minmapOpen.gameObject.SetActive(false);
        minmapClose.gameObject.SetActive(true);
    }
}
