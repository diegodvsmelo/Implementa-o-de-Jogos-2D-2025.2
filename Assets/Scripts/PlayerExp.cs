using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [Header("Variáveis de Nível")]
    public float xpToLevelUp;
    public float currentXp;
    public int level;
    public float xpMultiplierIncrease;

    void Awake()
    {
        currentXp=0;
        level = 1;
    }

    public void AddExp(float amount)
    {
        currentXp += amount;

        while (currentXp >= xpToLevelUp)
        {
            currentXp -= xpToLevelUp; 
            
            level++;
            
            xpToLevelUp *= xpMultiplierIncrease;
            HandleLevelUp(); 
        }
    }

    public void HandleLevelUp()
    {
        //Ativar GameObject da Tela de Level up e setar Time.timescale = 0 (lembrando de quando escolher o upgrade setar ele de volta pra 1)
    }
}
