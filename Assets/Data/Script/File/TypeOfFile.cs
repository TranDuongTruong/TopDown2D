using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfFile : SaiMonoBehaviour
{
    [SerializeField] protected List< SpriteRenderer> typeOfFiles;
    public List<SpriteRenderer> TypeOfFiles => typeOfFiles;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadSpriteRenderer();
    }
    protected virtual void LoadSpriteRenderer()
    {
        Transform[] child=transform.GetComponentsInChildren<Transform>();
        foreach (Transform child2 in child)
        {
            if (child2.GetComponent<SpriteRenderer>() != null)
            {
                typeOfFiles.Add(child2.GetComponent<SpriteRenderer>());
                child2.gameObject.SetActive(false);
            }
        }


    }
}
