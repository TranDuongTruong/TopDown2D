using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSkil : SaiMonoBehaviour
{
    
    [SerializeField] public float damage = 3f;
    [SerializeField] float speed = 45;
    [SerializeField] float time = 0;
    [SerializeField] float useTime = 3;
    [SerializeField] float delay = 3;
    [SerializeField] bool cooling = false;
    [SerializeField] List<Transform> objs = new List<Transform>();
    [SerializeField] public string skillName = "Laser";
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadLaser();
    }
    protected virtual void LoadLaser()
    {
        if (this.objs.Count > 0) return;

       Transform [] lines=transform.GetComponentsInChildren<Transform>();
        foreach (Transform prefab in lines)
        {
            if(prefab.name==skillName)
            this.objs.Add(prefab);
        }
    }
    public int direction = 1;
    
    private void Update()
    {
        if (cooling)
        {
            delay -= Time.deltaTime;
            if (delay <= 0f)
            {
                cooling = false; // K?t thúc cooldown
            }
        }
        else
        {
            time += Time.deltaTime;

            if (time < useTime)
            {
                foreach (Transform obj in objs)
                {
                    obj.gameObject.SetActive(true);
                    obj.rotation *= Quaternion.Euler(0f, 0f, speed * Time.deltaTime * direction);
                }
            }
            else
            {
                time = 0f;
                cooling = true; // B?t ??u cooldown
                delay = 2f;
                direction = GetRandomDirection();
                foreach (Transform obj in objs)
                {
                    obj.gameObject.SetActive(false);
                    obj.rotation = Quaternion.Euler(0f, 0f, GetRandomAngle());
                }
            }
        }
    }

    private int GetRandomDirection()
    {
        return Random.Range(0, 2) * 2 - 1;
    }

    private float GetRandomAngle()
    {
        return Random.Range(0f, 360f);
    }
}
