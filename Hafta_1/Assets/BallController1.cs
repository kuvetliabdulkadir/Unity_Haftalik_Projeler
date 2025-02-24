using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class BallController1 : MonoBehaviour
{
    public float moveSpeed = 25f;  // Hareket hızı
    public float jumpForce = 8f;    // Zıplama kuvveti
    public float fallThreshold = -5f; // Düşme sınırı (Y ekseninde)

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 startPosition;  // Başlangıç pozisyonu

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position; // Oyunun başındaki pozisyonu kaydet
    }

    void Update()
    {
        // Hareket girdilerini al
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Hareket vektörünü oluştur
        Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;

        // Rigidbody kullanarak hareket ettir
        rb.MovePosition(transform.position + movement);

        // Space tuşuna basıldığında ve yerdeyse zıpla
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Top belirli bir yüksekliğin altına düşerse başlangıç pozisyonuna dön
        if (transform.position.y < fallThreshold)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        rb.linearVelocity = Vector3.zero; // Hareketi durdur
        rb.angularVelocity = Vector3.zero; // Dönmeyi durdur
        transform.position = startPosition; // Başlangıç pozisyonuna dön
    }

    //Topun yerde olup olmadığını kontrol et
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
