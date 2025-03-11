using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 6f;
    public float fallThreshold = -8f;

    private Rigidbody rb;
    private Vector3 startPosition;
    private int jumpCount = 0;
    private int maxJumps = 1;
    private HealthManager healthManager;

    public GameObject winText; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody bulunamadı! Lütfen Top objesine Rigidbody ekleyin.");
            return;
        }

        startPosition = transform.position;
        rb.linearDamping = 1f;
        rb.angularDamping = 1f;

        healthManager = FindAnyObjectByType<HealthManager>();
        if (healthManager == null)
        {
            Debug.LogError("HealthManager sahnede bulunamadı!");
        }

        if (winText != null)
        {
            winText.SetActive(false); 
        }
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * moveSpeed;
        rb.AddForce(movement, ForceMode.Acceleration);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Engel"))
        {
            healthManager.DecreaseHealth(1);
        }

        jumpCount = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLine")) 
        {
            WinGame();
        }
    }


    void WinGame()
    {
        if (winText != null)
        {
            winText.SetActive(true);
        }
        Debug.Log("Tebrikler! Kazandınız!");
        Invoke("RestartGame", 2f); 
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
