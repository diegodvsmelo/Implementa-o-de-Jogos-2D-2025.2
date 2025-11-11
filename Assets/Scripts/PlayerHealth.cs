using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;
    public GameObject gameOverScreen;

    public int currentHealthPlayer
    {
        get { return currentHealth; }
    }
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
