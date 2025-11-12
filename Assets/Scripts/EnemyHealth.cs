using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;
    public void Initialize(EnemyData data)
    {
        this.maxHealth = data.maxHealth;
        currentHealth = maxHealth;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
