using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    [Header("References")]
    public GameObject upgradeCanvasUI;
    public PlayerStats playerStats;

    [Header("Upgrade buttons")]
    public Button fisrtOption;
    public Button secondOption;
    public Button thirdOption;

    [Header("Upgrades values")]
    public float healthIncrease = 5f;
    public float damageIncrease = 5f;
    public float movespeedIncrease = 1f;

    void Start()
    {
        // Adiciona os listeners aos botões
        if (fisrtOption != null)
            fisrtOption.onClick.AddListener(() => SelecionarUpgrade("health"));

        if (secondOption != null)
            secondOption.onClick.AddListener(() => SelecionarUpgrade("damage"));

        if (thirdOption != null)
            thirdOption.onClick.AddListener(() => SelecionarUpgrade("movespeed"));
    }

    public void SelecionarUpgrade(string tipoUpgrade)
    {
        if (playerStats == null)
        {
            Debug.LogError("PlayerStats não está atribuído!");
            return;
        }

        // Aplica o upgrade baseado no tipo
        switch (tipoUpgrade.ToLower())
        {
            case "health":
                playerStats.maxHealth += healthIncrease;
                playerStats.currentHealth += healthIncrease;
                Debug.Log($"Vida aumentada! Nova vida: {playerStats.maxHealth}");
                break;

            case "damage":
                playerStats.damage += damageIncrease;
                Debug.Log($"Dano aumentado! Novo dano: {playerStats.damage}");
                break;

            case "movespeed":
                playerStats.movespeed += movespeedIncrease;
                Debug.Log($"Velocidade aumentada! Nova velocidade: {playerStats.movespeed}");
                break;

            default:
                Debug.LogWarning($"Tipo de upgrade desconhecido: {tipoUpgrade}");
                return;
        }

        // Fecha o canvas de upgrade
        CloseCanvasUpgrade();
    }

    void CloseCanvasUpgrade()
    {
        if (upgradeCanvasUI != null)
        {
            upgradeCanvasUI.SetActive(false);
            Time.timeScale = 1f; // Resume o jogo caso esteja pausado
        }
    }

    public void OpenCanvasUpgrade()
    {
        if (upgradeCanvasUI != null)
        {
            upgradeCanvasUI.SetActive(true);
            Time.timeScale = 0f; // Pausa o jogo
        }
    }
}