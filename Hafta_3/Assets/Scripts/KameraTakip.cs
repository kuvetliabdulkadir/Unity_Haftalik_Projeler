using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform top;
    public Vector3 offset = new Vector3(0, 3, -8);
    public float takipHizi = 10f;

    void LateUpdate()
    {
        if (top != null)
        {
            Vector3 hedefPozisyon = top.position + offset;
            transform.position = Vector3.Lerp(transform.position, hedefPozisyon, takipHizi * Time.deltaTime);
        }
    }
}



