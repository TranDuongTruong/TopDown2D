using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEffectSpawner : Spawner
{
    private static SwordEffectSpawner instance;
    public static SwordEffectSpawner Instance => instance;

    public string effectHorizontal= "FileHorizontal";
    public string effectTopLeft= "FileTopLeft";
    public Quaternion rotTopLeft;
    public string effectTopRight= "FileTopRight";
    public Quaternion rotTopRight;
    public string effectDownRight= "FileDownRight";
    public Quaternion rotDownRight;
    public string effectDownLeft= "FileDownLeft";
    public Quaternion rotDownLeft;
    public string effectTop="FileTop";
    public string effectDown="FileDown";
    
    [SerializeField] protected TypeOfFile  typeOfFile;
    [SerializeField] public SpriteRenderer sprite = new SpriteRenderer();
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadTypeOfEffect();
    }
    protected virtual void LoadTypeOfEffect()
    {
        if (typeOfFile == null)
        {
            typeOfFile = transform.GetComponentInChildren<TypeOfFile>();
        }
    }
    protected override void Awake()
    {
        base.Awake();
        if (SwordEffectSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        SwordEffectSpawner.instance = this;
        SetTypeOfEffect("Normal");

    }
    public FileControler[] holderObjs;
    public void SetTypeOfEffect(string name)
    {
 
        foreach (SpriteRenderer sprite1 in typeOfFile.TypeOfFiles)
        {
            if (sprite1.name == name) sprite = sprite1;
        }
        if (sprite != null)
        {
            foreach(Transform prefab in prefabs)
            {
                FileControler fileControler= prefab.GetComponent<FileControler>();
                if(fileControler != null)
                {
                    fileControler.spriteRenderer.sprite = sprite.sprite;
                    fileControler.typeOfFile = name;
                   
                }
            }
          /*  foreach (Transform prefab in poolObjs)
            {
                FileControler fileControler = prefab.GetComponent<FileControler>();
                if (fileControler != null)
                {
                    fileControler.spriteRenderer.sprite = sprite.sprite;
                    Debug.Log(sprite.name);
                    fileControler.typeOfFile = name;
                }
            }*/
           holderObjs=holder.transform.GetComponentsInChildren<FileControler>();
            for(int i = 0; i < holderObjs.Length; i++)
            {
                
                
                //holderObjs[i] = null;
                Destroy(holderObjs[i].gameObject);
            }
            holderObjs=null;
          for (int i = 0; i < poolObjs.Count; i++)
            {
                Transform obj= poolObjs[i];
                poolObjs[i]=null;           
                Destroy(obj.gameObject);
            }
            poolObjs.Clear();
        }
    }
}

