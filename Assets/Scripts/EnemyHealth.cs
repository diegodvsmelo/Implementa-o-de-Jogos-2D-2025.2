using Unity.Mathematics;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    [SerializeField] private int currentHealth;
    public void Initialize(EnemyData data, float statMultiplier)
    {
        this.maxHealth = (int)(data.maxHealth*statMultiplier);
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
