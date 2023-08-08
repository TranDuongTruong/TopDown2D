using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class MinimapSpotLightControler : SaiMonoBehaviour
{
    [SerializeField] public Light2D spotLight;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        spotLight = GetComponent<Light2D>();
        spotLight.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spotLight.enabled = true;
        }

    }

}
