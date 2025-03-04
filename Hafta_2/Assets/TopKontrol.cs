using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopKontrol : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 6f;
    public float fallThreshold = -8f;

    private Rigidbody rb;
    private Vector3 startPosition;
    private int jumpCount = 0;
    private int maxJumps = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody bulunamad�! L�tfen Top objesine Rigidbody ekleyin.");
            return;
        }

        startPosition = transform.position;

        // Fiziksel s�r�klenmeyi ayarlayal�m
        rb.linearDamping = 1f; // Hareket s�rt�nmesi
        rb.angularDamping = 1f; // D�n�� s�rt�nmesi
    }

    void Update()
    {
        if (rb == null) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed;
        rb.AddForce(movement, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); // Y eksenini s�f�rla
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount++;
        }

        if (transform.position.y < fallThreshold)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
        jumpCount = 0;
    }

    private void OnCollisionStay(Collision collision)
    {
        jumpCount = 0; // yere de�ince z�plama hakk�n� s�f�rla
    }
}
