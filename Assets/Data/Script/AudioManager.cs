using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public GameObject prefab;
    public AudioClip walk;
    private AudioSource walkSource;
    public AudioClip run;
    private AudioSource runSource;
    public AudioClip attack;
    private AudioSource attackSource;
    public AudioClip fireOfFile;
    private AudioSource fileOfFileSource;
    public AudioClip iceOfFile;
    public AudioSource iceOfFileSource;
    public AudioClip poisionFile;
    private AudioSource poisionFileSource;
    public AudioClip spiritSkill;
    private AudioSource spiritSkillSource;
    public AudioClip electricSkill;
    private AudioSource electricSkillSource;
    public AudioClip rocketSkill;
    private AudioSource rockerSkillSource;
    public AudioClip exploreObj;
    private AudioSource exploreObjSource;
    public AudioClip finish;
    private AudioSource finishSource;
    public AudioClip bg;
    private AudioSource bgSource;
    public AudioClip upgradeLvl;
    private AudioSource upgradeLvlSource;

    public AudioClip spawnEnemy;
    private AudioSource spawnEnemySource;
    public AudioClip collection;
    private AudioSource collectionSource;
    public AudioClip musicOfLevel;
    private AudioSource musicOfLevelSource;
    public AudioClip gameOver;
    private AudioSource gameOverSource;



    private void Awake()
    {
        instance = this;
       PlayAudio(AudioManager.instance.musicOfLevel, 0.015f,true);
    }
    public void PlayAudio(AudioClip clip, float volume, bool isLoopBack)
    {
        if ((clip == this.walk))
        {
            Play(clip, ref walkSource, volume, isLoopBack);
        }
        if (clip == this.run)
        {

            Play(clip, ref runSource, volume, isLoopBack);
            return;
        }

        if (clip == this.iceOfFile)
        {

            Play(clip, ref iceOfFileSource, volume, isLoopBack);
            return;
        }

        if (clip == this.poisionFile)
        {

            Play(clip, ref poisionFileSource, volume, isLoopBack);
            return;
        }
        if (clip == this.attack)
        {

            Play(clip, ref attackSource, volume, isLoopBack);
            return;
        }
        if (clip == this.spiritSkill)
        {

            Play(clip, ref spiritSkillSource, volume, isLoopBack);
            return;
        }
        if (clip == this.electricSkill)
        {
            electricSkillSource.SetScheduledEndTime(0.2f);
            Play(clip, ref electricSkillSource, volume, isLoopBack);

            return;
        }
        if (clip == this.rocketSkill)
        {

            Play(clip, ref rockerSkillSource, volume, isLoopBack);
            return;
        }
        if (clip == this.exploreObj)
        {

            Play(clip, ref exploreObjSource, volume, isLoopBack);
            return;
        }
        if (clip == this.finish)
        {

            Play(clip, ref finishSource, volume, isLoopBack);
            return;
        }
        if (clip == this.bg)
        {

            Play(clip, ref bgSource, volume, isLoopBack);
            return;
        }
        if (clip == this.upgradeLvl)
        {

            Play(clip, ref upgradeLvlSource, volume, isLoopBack);
            return;
        }
        if (clip == this.spawnEnemy)
        {

            Play(clip, ref spawnEnemySource, volume, isLoopBack);
            return;
        }
        if (clip == this.collection)
        {

            Play(clip, ref collectionSource, volume, isLoopBack);
            return;
        }
        if (clip == this.musicOfLevel)
        {

            Play(clip, ref musicOfLevelSource, volume, isLoopBack);
            return;
        }
    }
    public void PlayAudio(AudioClip clip, float volume)
    {
        if (clip == this.walk)
        {

            Play(clip, ref walkSource, volume);
            return;
        }
        if (clip == this.run)
        {

            Play(clip, ref runSource, volume);
            return;
        }

        if (clip == this.iceOfFile)
        {

            Play(clip, ref iceOfFileSource, volume);

            return;
        }

        if (clip == this.poisionFile)
        {

            Play(clip, ref poisionFileSource, volume);
            return;
        }
        if (clip == this.attack)
        {

            Play(clip, ref attackSource, volume);
            return;
        }
        if (clip == this.spiritSkill)
        {

            Play(clip, ref spiritSkillSource, volume);
            return;
        }
        if (clip == this.electricSkill)
        {

            Play(clip, ref electricSkillSource, volume);
            return;
        }
        if (clip == this.rocketSkill)
        {

            Play(clip, ref rockerSkillSource, volume);
            return;
        }
        if (clip == this.exploreObj)
        {

            Play(clip, ref exploreObjSource, volume);
            return;
        }
        if (clip == this.finish)
        {

            Play(clip, ref finishSource, volume);
            return;
        }
        if (clip == this.bg)
        {

            Play(clip, ref bgSource, volume);
            return;
        }
        if (clip == this.upgradeLvl)
        {

            Play(clip, ref upgradeLvlSource, volume);
            return;
        }
        if (clip == this.spawnEnemy)
        {

            Play(clip, ref spawnEnemySource, volume);
            return;
        }
        if (clip == this.collection)
        {

            Play(clip, ref collectionSource, volume);
            return;
        }


    }
    private void Play(AudioClip clip, ref AudioSource audioSource, float volume, bool isLoopBack = false)
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            return;
        }
        audioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();
        audioSource.volume = volume;
        audioSource.loop = isLoopBack;
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
    private void Play2(AudioClip clip, ref AudioSource audioSource, float volume, bool isLoopBack = false)
    {
        if (audioSource != null )
        {
           return ;
        }
         AudioSource newaudioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();
        newaudioSource = Instantiate(instance.prefab).GetComponent<AudioSource>();
        newaudioSource.volume = volume;
        newaudioSource.loop = isLoopBack;
        newaudioSource.clip = clip;
        newaudioSource.Play();


        Destroy(newaudioSource.gameObject, audioSource.clip.length);
    }
    private void Play3(AudioClip clip, ref List<AudioSource> audioSources, float volume, bool isLoopBack = false)
    {
        AudioSource availableSource = audioSources.Find(source => !source.isPlaying);

        if (availableSource == null)
        {
            GameObject audioGO = Instantiate(instance.prefab);
            availableSource = audioGO.GetComponent<AudioSource>();
            audioSources.Add(availableSource);
        }

        availableSource.volume = volume;
        availableSource.loop = isLoopBack;
        availableSource.clip = clip;
        availableSource.Play();
    }

    public void StopSound(AudioClip clip)
    {
        if (clip == this.iceOfFile)
        {
            iceOfFileSource?.Stop();
            return;
        }
        if (clip == this.attack)
        {
            attackSource?.Stop();
            return;
        }
        if (clip == this.musicOfLevel)
        {
            musicOfLevelSource?.Stop();
            return;
        }
        if (clip == this.run)
        {
            runSource?.Stop();
            return;
        }
        if (clip == this.walk)
        {
            walkSource?.Stop();
            return;
        }
        if (clip == this.upgradeLvl)
        {
            upgradeLvlSource?.Stop();
            return;
        }
    }
}
