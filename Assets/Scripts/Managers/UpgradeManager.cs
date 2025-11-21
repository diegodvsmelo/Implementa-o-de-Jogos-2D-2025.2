using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradeCanvasUI;
    public PlayerStats playerStats;

    [Header("Variáveis Vida")]
    public Button btnHealth;
    public TextMeshProUGUI healthtxt;
    public int healthToAdd = 20;
    [Header("Variáveis Dano")]
    public Button btnDamage;
    public float damageToAdd= 0.1f;
    public TextMeshProUGUI damagetxt;
    [Header("Variáveis Movimentação")]
    public Button btnSpeed;
    public float speedToAdd = 0.5f;
    public TextMeshProUGUI speedtxt;
    [Header("Variáveis Tempo")]
    public Button btnCooldown;
    public TextMeshProUGUI cooldowntxt;
    public float cooldownToAdd = 0.1f;

    void Start()
    {
        if(upgradeCanvasUI != null) upgradeCanvasUI.SetActive(false);

        if(btnHealth!=null)btnHealth.onClick.AddListener(() => ApplyUpgrade("health"));
        if(btnDamage!=null)btnDamage.onClick.AddListener(() => ApplyUpgrade("damage"));
        if(btnSpeed!=null)btnSpeed.onClick.AddListener(() => ApplyUpgrade("speed"));
        if(btnCooldown!=null)btnCooldown.onClick.AddListener(() => ApplyUpgrade("cooldown"));
        UpdateUI();
    }

    public void ApplyUpgrade(string type)
    {
        if (playerStats == null) return;

        switch (type)
        {
            case "health":
                playerStats.UpgradeHealth(healthToAdd); // +20 Vida
                 
                break;
            case "damage":
                playerStats.UpgradeDamage(damageToAdd); // +10% Dano
                
                break;
            case "speed":
                playerStats.UpgradeSpeed(speedToAdd); // +0.5 Velocidade
                
                break;
            case "cooldown":
                playerStats.UpgradeCooldown(cooldownToAdd); //-10% Cooldown
                
                break;
        }
        CloseUpgradeMenu();
    }

    public void OpenUpgradeMenu()
    {
        UpdateUI();
        upgradeCanvasUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseUpgradeMenu()
    {
        upgradeCanvasUI.SetActive(false);
        Time.timeScale = 1f;
    }
    
    private void UpdateUI()
    {
        if(healthtxt!=null)healthtxt.text = "+ "+ healthToAdd+ " HP";
        if(damagetxt!=null)damagetxt.text = "+ "+ (damageToAdd*100)+"% damage";
        if(speedtxt!=null)speedtxt.text = "+ "+ speedToAdd+ " speed";
        if(cooldowntxt!=null)cooldowntxt.text = "- "+(cooldownToAdd*100)+"% cooldown";
    }
}