using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileControler : SaiMonoBehaviour
{
    [SerializeField] public FileFly fileFly;
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] protected FileDespawn fileDespawn;
    [SerializeField] protected FileDamageSender fileDamageSender;
    [SerializeField] protected EffectOfFile effectOfFile;
   
    public EffectOfFile EffectOfFile => effectOfFile;
    public FileDamageSender FileDamageSender => fileDamageSender;
    public FileDespawn FileDespawn => fileDespawn;
    public string typeOfFile = "Normal";
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadFileFly(); LoadSpriteRenderer(); LoadDespawn(); LoadFileDamageSender(); LoadEffectOfFile();
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
    protected virtual void LoadEffectOfFile()
    {
        if (effectOfFile == null)
        {
            effectOfFile = transform.GetComponentInChildren<EffectOfFile>();
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
