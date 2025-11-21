using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Atributos de Vida")]
    public int maxHealth;
    public int currentHealth;
    [Header("Atributos de Movimento")]
    public float moveSpeed;
    [Header("Atributos de Combate")]
    public float globalDamageMultiplier;
    public float cooldownReductionMultiplier;


    private PlayerHealth playerHealthScript;

    void Awake()
    {
        playerHealthScript = GetComponent<PlayerHealth>();
        currentHealth = maxHealth;
    }

    //-----Funções de Upgrade-----
    public void UpgradeHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
        Debug.Log("Vida Aumentada! Max: " + maxHealth);
    }

    public void UpgradeSpeed(float amount)
    {
        moveSpeed += amount;
        Debug.Log("Velocidade Aumentada! Nova: " + moveSpeed);
    }

    public void UpgradeDamage(float percentage)
    {
        globalDamageMultiplier += percentage;
        Debug.Log("Dano Multiplicado! Novo: " + globalDamageMultiplier);
    }
}
