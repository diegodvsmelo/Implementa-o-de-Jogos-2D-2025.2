using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Security.Cryptography;
using UnityEngine.Rendering;

public class UiDebug : MonoBehaviour
{
    [Header("WaveInfo")]
    public TextMeshProUGUI leveltxt;
    public TextMeshProUGUI statMultitxt;
    public TextMeshProUGUI cdMultitxt;

    [Header("ComboInfo")]
    public ComboManager comboManager;
    public GameObject debugUI;
    public bool isDebugUIActive;

    public TextMeshProUGUI comboText;
    public TextMeshProUGUI cooldownText;

    [Header("PlayerStats")]
    public GameObject player;
    private PlayerStats stats;
    public TextMeshProUGUI currentHealthtxt;
    public TextMeshProUGUI maxHealthtxt;
    void Start()
    {
       stats = player.GetComponent<PlayerStats>();
    }
    void Update()
    {
        
        UpdatePlayerStats();
        if (!isDebugUIActive)
        {
            debugUI.SetActive(false);
        }
        else
        {
            debugUI.SetActive(true);
            UpdateComboText();
            UpdateCooldownsText();
            UpdateWaveInfo();
        }
    }
    void UpdateComboText()
    {
        string comboName = comboManager.LastUsedComboName;


        if (string.IsNullOrEmpty(comboName))
        {
            comboText.text = "Último Combo: N/A";
            return;
        }


        var tracker = comboManager.CooldownTracker;


        ComboData foundRecipe = null;
        foreach (ComboData recipe in comboManager.comboRecipes)
        {

            if (recipe.name == comboName)
            {
                foundRecipe = recipe;
                break;
            }
        }

        if (foundRecipe != null && tracker.ContainsKey(comboName))
        {

            float duration = foundRecipe.coolDown;
            float timePassed = Time.time - tracker[comboName];
            float timeRemaining = duration - timePassed;

            if (timeRemaining > 0)
            {

                comboText.text = "Último Combo: " + comboName + " (" + timeRemaining.ToString("F1") + "s)";
            }
            else
            {

                comboText.text = "Último Combo: " + comboName + " (Pronto)";
            }
        }
        else
        {

            comboText.text = "Último Combo: " + comboName;
        }
    }

    void UpdateCooldownsText()
    {
        string cdString = "Cooldowns:\n";

        var tracker = comboManager.CooldownTracker;


        foreach (SkillData skill in comboManager.skillRecipes)
        {
            string skillName = skill.key1;
            float duration = skill.coolDown;

            if (tracker.ContainsKey(skillName))
            {

                float timePassed = Time.time - tracker[skillName];
                float timeRemaining = duration - timePassed;

                if (timeRemaining > 0)
                {

                    cdString += skillName + ": " + timeRemaining.ToString("F1") + "s\n";
                }
                else
                {

                    cdString += skillName + ": Pronto\n";
                }
            }
            else
            {

                cdString += skillName + ": Pronto\n";
            }
        }


        cooldownText.text = cdString;
    }
    void UpdatePlayerStats()
    {
        if(player !=null)
        {
            if(stats!=null)
            {
                maxHealthtxt.text = "Max: "+stats.maxHealth.ToString();
                currentHealthtxt.text = "Current: "+stats.currentHealth.ToString();
            }
        }
    }
    void UpdateWaveInfo()
    {
        EnemySpawner enemySpawner = GameObject.FindWithTag("EnemySpawner").GetComponent<EnemySpawner>();
        leveltxt.text = "Wave: "+ enemySpawner.WaveLevelUI;
        statMultitxt.text = "Stat Multiplier: "+ enemySpawner.StatMultiplierUI;
        cdMultitxt.text = "CooldownMulti: "+ enemySpawner.CooldownMultiplierUI;
    }
}
