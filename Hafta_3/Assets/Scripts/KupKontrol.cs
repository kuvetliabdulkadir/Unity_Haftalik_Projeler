using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KupKontrol : MonoBehaviour
{
    private new Renderer renderer;

    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Top"))
        {
            ChangeColor();
        }
    }

    void ChangeColor()
    {
        renderer.material.color = Color.red; // Küp çarpýþýnca kýrmýzýya döner
    }
}
