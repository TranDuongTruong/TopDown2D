using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasCtr_lMainMenu : SaiMonoBehaviour
{
    [SerializeField] public Button playButton;
    [SerializeField] public Button researchButton;
    
    [SerializeField] public Button settingButton;
    [SerializeField] public SkillSystem_MainMenu skillSystem;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadnButton(); LoadSkillSystem();
    }
    protected override void Awake()
    {
        playButton.onClick.AddListener(PlayGame);
        researchButton.onClick.AddListener(Research);
        settingButton.onClick.AddListener(Setting);
    }
    protected void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }
    protected void Setting()
    {
        Debug.Log("aaa");
    }
    protected void Research()
    {
        skillSystem.gameObject.SetActive(true);
    }
    protected virtual void LoadSkillSystem()
    {
        if(skillSystem == null)
        skillSystem=transform.GetComponentInChildren<SkillSystem_MainMenu>();
        skillSystem.gameObject.SetActive(false);
    }
    protected virtual void LoadnButton()
    {
        Button[] contents = transform.GetComponentsInChildren<Button>();
        foreach (Button content in contents)
        {
            if (content.name == "PlayButton") this.playButton = content;
            if (content.name == "ResearchButton") this.researchButton = content;
            if (content.name == "SettingButton") this.settingButton = content;
         

        }
    }
}
