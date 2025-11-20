using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Player attributes")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;
    public float damage = 10f;
    public float coolDownShoot = 0.8f;
    public float movespeed = 7f;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ReceiveDamage(float quantidade)
    {
        currentHealth -= quantidade;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        Debug.Log("Player morreu!");
        // Adicione aqui a lógica de morte
    }
}