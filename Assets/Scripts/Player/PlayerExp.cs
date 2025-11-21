using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [Header("Variáveis de Nível")]
    public float xpToLevelUp;
    public float currentXp;
    public int level;
    public float xpMultiplierIncrease;
    public UpgradeManager upgradeManager;

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
        if(upgradeManager!=null) upgradeManager.OpenUpgradeMenu();
    }
}
