using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskCtrl : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI mainText;
    private void Update()
    {
        mainText.text =  GameManager.Instance.BossSystem.numOfBoss+ "/" +GameManager.Instance.BossSystem.BossCtrls.Count ;
    }
}
