using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class FinishGateCtrl : SaiMonoBehaviour
{
    [SerializeField] PlayerControler playerControler;
    [SerializeField] Transform holdPoint;

    [SerializeField] bool isPulling = false; // Bi?n ki?m tra xem có ?ang hút không
    [SerializeField] bool startHold = false; // Bi?n ki?m tra xem có ?ang hút không

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerControler = collision.GetComponent<PlayerControler>();
            isPulling = true; // B?t ??u hút khi ti?p xúc
            startHold = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerControler = null;
            isPulling = false; // B?t ??u hút khi ti?p xúc
        }
    }

    private void Update()
    {
        if(startHold)
        if (isPulling)
        {
            playerControler.moveSpeed = 500;
        }
            else
            {
                SceneManager.LoadScene("MainMenu");
            }
    }
}

