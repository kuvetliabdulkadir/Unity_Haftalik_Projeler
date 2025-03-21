using UnityEngine;

public class CoinMover : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector3 moveDirection;

    void Start()
    {
        moveDirection = Vector3.back;
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.IncreaseScore();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("ScoreManager sahnede bulunamadý!");
            }
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}