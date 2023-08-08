using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffectSpawner : Spawner
{
    private static SwordEffectSpawner instance;
    public static SwordEffectSpawner Instance => instance;

    public string effectHorizontal= "FileHorizontal";
    public string effectTop="FileTop";
    public string effectDown="FileDown";

    protected override void Awake()
    {
        base.Awake();
        if (SwordEffectSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        SwordEffectSpawner.instance = this;
    }
}

