using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverCtrl : SaiMonoBehaviour
{
    [SerializeField] PlayerControler playerControler;
    [SerializeField] CanvasCtrl canvasCtrl;
    [SerializeField] Transform gameOverPanel;
    [SerializeField] TextMeshProUGUI  content;
    [SerializeField] Button continueBtn;
    [SerializeField] Button replayBtn;
    [SerializeField] string nameScene="LV1";
    
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadComponent();
    }
    protected override void Awake()
    {
        base.Awake();
        continueBtn.onClick.AddListener(LoadMainSence);
        replayBtn.onClick.AddListener(Replay);
    }
    public void LoadMainSence()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nameScene);
    }
    protected virtual void LoadComponent()
    {
        if(playerControler == null)
        {
            playerControler=Transform.FindObjectOfType<PlayerControler>();

        }
        if(canvasCtrl == null)
        {
            canvasCtrl=transform.parent.GetComponent<CanvasCtrl>();
        }
        if(gameOverPanel == null)
        {
            Transform[]tmp=transform.GetComponentsInChildren<Transform>();
            foreach(Transform t in tmp)
            {
                if (t.name == "GameOverPanel")
                {
                    gameOverPanel = t;
                    gameOverPanel.gameObject.SetActive(false);
                }
                if(t.name =="Content") content=t.transform.GetComponent<TextMeshProUGUI>();
            }
        }
    }
    private void Update()
    {
        if(gameOverPanel != null)
        {
            content.text = "\nTime\t\t\t:" + canvasCtrl.mainTime.text+ "\n\nLevel\t\t\t:" + playerControler.PlayerStatus.level+ "\n\nDamage\t\t:" + playerControler.PlayerStatus.damage+"\n\nEnemy\t\t:"+GameManager.Instance.killCount;


        }
    }
    public void OpenGamePanel()
    {
        Time.timeScale = 0;
        gameOverPanel.gameObject.SetActive(true);
    }
}
