using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        SwordEffectSpawner.Instance.Despawn(transform.parent);
    }
}
