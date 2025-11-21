using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgradeCanvasUI;
    public PlayerStats playerStats;

    public Button btnHealth;
    public Button btnDamage;
    public Button btnSpeed;

    void Start()
    {
        if(upgradeCanvasUI != null) upgradeCanvasUI.SetActive(false);

        if(btnHealth!=null)btnHealth.onClick.AddListener(() => ApplyUpgrade("health"));
        if(btnDamage!=null)btnDamage.onClick.AddListener(() => ApplyUpgrade("damage"));
        if(btnSpeed!=null)btnSpeed.onClick.AddListener(() => ApplyUpgrade("speed"));
    }

    public void ApplyUpgrade(string type)
    {
        if (playerStats == null) return;

        switch (type)
        {
            case "health":
                playerStats.UpgradeHealth(20); // +20 Vida
                break;
            case "damage":
                playerStats.UpgradeDamage(0.1f); // +10% Dano
                break;
            case "speed":
                playerStats.UpgradeSpeed(0.5f); // +0.5 Velocidade
                break;
        }
        CloseUpgradeMenu();
    }

    public void OpenUpgradeMenu()
    {
        upgradeCanvasUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseUpgradeMenu()
    {
        upgradeCanvasUI.SetActive(false);
        Time.timeScale = 1f;
    }
}