using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform top; // Takip edilecek top (Top objesini buraya s�r�kleyip b�rak)
    public Vector3 offset = new Vector3(0, 3, -8); // Kameran�n topa olan mesafesi
    public float takipHizi = 10f; // Kameran�n ne kadar h�zl� takip edece�i

    void LateUpdate()
    {
        if (top != null)
        {
            Vector3 hedefPozisyon = top.position + offset;
            transform.position = Vector3.Lerp(transform.position, hedefPozisyon, takipHizi * Time.deltaTime);
        }
    }
}



