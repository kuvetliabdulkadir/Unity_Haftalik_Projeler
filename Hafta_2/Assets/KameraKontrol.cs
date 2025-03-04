using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform top; // Takip edilecek top (Top objesini buraya sürükleyip býrak)
    public Vector3 offset = new Vector3(0, 3, -8); // Kameranýn topa olan mesafesi
    public float takipHizi = 10f; // Kameranýn ne kadar hýzlý takip edeceði

    void LateUpdate()
    {
        if (top != null)
        {
            Vector3 hedefPozisyon = top.position + offset;
            transform.position = Vector3.Lerp(transform.position, hedefPozisyon, takipHizi * Time.deltaTime);
        }
    }
}



