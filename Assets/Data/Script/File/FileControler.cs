using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileControler : SaiMonoBehaviour
{
    [SerializeField] public FileFly fileFly;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] protected FileDespawn fileDespawn;
    [SerializeField] protected FileDamageSender fileDamageSender;
    public FileDamageSender FileDamageSender => fileDamageSender;
    public FileDespawn FileDespawn => fileDespawn;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadFileFly(); LoadSpriteRenderer(); LoadDespawn(); LoadFileDamageSender();
    }
    protected virtual void LoadFileFly()
    {
        if (fileFly == null)
        {
            fileFly=transform.GetComponentInChildren<FileFly>();
        }
    } 
    protected virtual void LoadSpriteRenderer()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer=transform.GetComponentInChildren<SpriteRenderer>();
        }
    }
    protected virtual void LoadDespawn ()
    {
        if (fileDespawn == null)
        {
            fileDespawn = transform.GetComponentInChildren<FileDespawn>();
        }
    }
    protected virtual void LoadFileDamageSender()
    {
        if (fileDamageSender == null)
        {
            fileDamageSender = transform.GetComponentInChildren<FileDamageSender>();
        }
    }
}
