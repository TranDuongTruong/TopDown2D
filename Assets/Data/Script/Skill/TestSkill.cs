using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSkill : SaiMonoBehaviour
{

    [SerializeField] public float damage = 3f;
    [SerializeField] float speed = 45;
    [SerializeField] float time = 0;
    [SerializeField] float useTime = 3;
    [SerializeField] float delay = 3;
    [SerializeField] bool cooling = false;
    [SerializeField] Transform ball;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadLaser();
    }
    protected virtual void LoadLaser()
    {
       

      ball= transform.GetChild(0);
    }
}
