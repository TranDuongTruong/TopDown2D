using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanelCtrl : SaiMonoBehaviour
{
    [SerializeField] Button continueBtn;
    [SerializeField] Button exitBtn;
    protected override void LoadComponents()
    {
        base.LoadComponents(); LoadComponent();
    }
    protected override void Awake()
    {
        base.Awake();
        continueBtn.onClick.AddListener(ContinueBtn);
        exitBtn.onClick.AddListener(ExitBtn);
    }
   private void ContinueBtn()
    {
        Time.timeScale = 1.0f;
        transform.gameObject.SetActive(false);
    }
    private void ExitBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    protected virtual void LoadComponent()
    {
       
        if (continueBtn == null||exitBtn==null)
        {
            Transform[] tmp = transform.GetComponentsInChildren<Transform>();
            foreach (Transform t in tmp)
            {
                if (t.name == "ContinueBtn")
                {
                    continueBtn = t.transform.GetComponent<Button>();
                   
                }
                if (t.name == "ExitBtn")
                {
                    exitBtn = t.transform.GetComponent<Button>();

                }

            }
        }
    }
}
