using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerStats stats;
    public GameObject gameOverScreen;

    void Start()
    {
        stats = GetComponent<PlayerStats>();   
    }
    public void TakeDamage(int damage)
    {
        stats.currentHealth -= damage;
        if (stats.currentHealth <= 0)
        {
            PlayerDeath();
        }
    }

    public void Heal(int amount)
    {
        stats.currentHealth += amount;
        if(stats.currentHealth > stats.maxHealth)
        {
            stats.currentHealth = stats.maxHealth;
        }
    }

    public void PlayerDeath()
    {
        Destroy(this.gameObject);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
