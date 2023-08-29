using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingPanel : SaiMonoBehaviour
{
    [SerializeField] Button resumeBtn;
    [SerializeField] Slider audioVolume;
    [SerializeField] public AudioSO audioSO;
    [SerializeField] Button exitBtn;
    private void Update()
    {
       
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override void Awake()
    {
        base.Awake();
        resumeBtn.onClick.AddListener(Resume);
        exitBtn.onClick.AddListener(ExitAPP);
        audioVolume.value = audioSO.volume;
    }
    private void ExitAPP()
    {
        Application.Quit();
    }
    private void Resume()
    {
        audioSO.volume= audioVolume.value;
        Time.timeScale = 1;
        Debug.Log("aa");
        transform.gameObject.SetActive(false);
    }
}
