using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI i�in gerekli
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject gameOverText; // "�LD�N�Z" yaz�s�
    public TextMeshProUGUI timerText; // S�re sayac�
    public float timeLimit = 30f; // S�re s�n�r� (saniye)
    private float currentTime;

    public Slider healthBar; // Can bar�

    void Start()
    {
        currentHealth = maxHealth;
        currentTime = timeLimit;

        if (gameOverText != null)
        {
            gameOverText.SetActive(false); // Ba�lang��ta g�r�nmesin
        }

        
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    void Update()
    {
        // S�reyi azalt
        currentTime -= Time.deltaTime;
        if (timerText != null)
        {
            timerText.text = "S�re: " + Mathf.Ceil(currentTime).ToString();
        }

        // S�re bitince oyunu bitir
        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Can: " + currentHealth);

        // Can bar�n� g�ncelle
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.SetActive(true); // "�LD�N�Z" yaz�s�n� g�ster
        }
        Debug.Log("Oyun bitti!");
        Invoke("RestartGame", 1f); 
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
