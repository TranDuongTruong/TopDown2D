using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChosingMapCtrl : SaiMonoBehaviour {

    [SerializeField] Button Lv1Btn;
    [SerializeField] Button Lv2Btn;
    [SerializeField] Button backBtn;


    protected override void Awake()
    {
        base.Awake();
        Lv1Btn.onClick.AddListener(() => LoadLevel("LV1"));
        Lv2Btn.onClick.AddListener(() => LoadLevel("LV2"));
        backBtn.onClick.AddListener(BackBtn);
    }
    private void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    private void BackBtn()
    {
        transform.gameObject.SetActive(false);
    }
}
