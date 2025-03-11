using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI için gerekli
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    public GameObject gameOverText; // "ÖLDÜNÜZ" yazýsý
    public TextMeshProUGUI timerText; // Süre sayacý
    public float timeLimit = 30f; // Süre sýnýrý (saniye)
    private float currentTime;

    public Slider healthBar; // Can barý

    void Start()
    {
        currentHealth = maxHealth;
        currentTime = timeLimit;

        if (gameOverText != null)
        {
            gameOverText.SetActive(false); // Baþlangýçta görünmesin
        }

        
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    void Update()
    {
        // Süreyi azalt
        currentTime -= Time.deltaTime;
        if (timerText != null)
        {
            timerText.text = "Süre: " + Mathf.Ceil(currentTime).ToString();
        }

        // Süre bitince oyunu bitir
        if (currentTime <= 0)
        {
            GameOver();
        }
    }

    public void DecreaseHealth(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Can: " + currentHealth);

        // Can barýný güncelle
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
            gameOverText.SetActive(true); // "ÖLDÜNÜZ" yazýsýný göster
        }
        Debug.Log("Oyun bitti!");
        Invoke("RestartGame", 1f); 
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
