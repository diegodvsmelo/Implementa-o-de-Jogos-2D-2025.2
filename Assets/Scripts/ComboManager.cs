using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComboManager : MonoBehaviour
{
    //APENAS COMBO Q+Q(FIRE+FIRE) ESTÁ ''IMPLEMENTADO'' FAZER COMBO COM QUALQUER OUTRA TECLA GERA ERRO DE FALTA DE INDEX NA LISTA
    private InputActions controls;
    private Vector2 worldPosition;

    public List<ComboData> comboRecipes;
    public List<SkillData> skillRecipes;
    public Dictionary<string, float> cooldownTracker;
    private List<ComboInput> inputBuffer;
    public float comboWindow = 300f;
    private Coroutine clearBuffer;

    private struct ComboInput
    {
        public string key;
        public float time;
    }
    void Awake()
    {
        cooldownTracker = new Dictionary<string, float>();
        controls = new InputActions();
        inputBuffer = new List<ComboInput>();
    }
    void OnEnable()
    {
        controls.PlayerControls.Enable();
        controls.PlayerControls.Fire.performed += FireHandler;
        controls.PlayerControls.Water.performed += WaterHandler;
        controls.PlayerControls.Air.performed += AirHandler;
        controls.PlayerControls.Earth.performed += EarthHandler;
    }
    void OnDisable()
    {
        controls.PlayerControls.Disable();
        controls.PlayerControls.Fire.performed -= FireHandler;
        controls.PlayerControls.Water.performed -= WaterHandler;
        controls.PlayerControls.Air.performed -= AirHandler;
        controls.PlayerControls.Earth.performed -= EarthHandler;
    }
    private void FireHandler(InputAction.CallbackContext context)
    {
        ComboInput input = new ComboInput { key = "Fire", time = Time.time };
        SkillData fireSkill = FindSkill("Fire");

        //Verificações de Falha
        if (fireSkill == null)
        {
            Debug.Log("Skill Fire não encontrada.");
            return;
        }

        if (IsOnCoolDown("Fire", fireSkill.coolDown))
        {
            Debug.Log("Fire ainda em cooldown.");
        }

        //Logica principal
        if (inputBuffer.Count > 0 && (Time.time - inputBuffer[0].time < comboWindow))
        {
            if (clearBuffer != null)
            {
                StopCoroutine(clearBuffer);
            }
            inputBuffer.Add(input);
            CheckForCombo();
            inputBuffer.Clear();
        }
        else
        {
            CastSimpleSkill(fireSkill);

            if (clearBuffer != null)
            {
                StopCoroutine(clearBuffer);
            }

            inputBuffer.Clear();
            inputBuffer.Add(input);
            clearBuffer = StartCoroutine(ClearBufferAfterTime());
        }

    }
    private void WaterHandler(InputAction.CallbackContext context)
    {
        ComboInput input = new ComboInput { key = "Water", time = Time.time };
        SkillData waterSkill = FindSkill("Water");

        //Verificações de Falha
        if (waterSkill == null)
        {
            Debug.Log("Skill Fire não encontrada.");
            return;
        }

        if (IsOnCoolDown("Fire", waterSkill.coolDown))
        {
            Debug.Log("Fire ainda em cooldown.");
        }

        //Logica principal
        if (inputBuffer.Count > 0 && (Time.time - inputBuffer[0].time < comboWindow))
        {
            if (clearBuffer != null)
            {
                StopCoroutine(clearBuffer);
            }
            inputBuffer.Add(input);
            CheckForCombo();
            inputBuffer.Clear();
        }
        else
        {
            CastSimpleSkill(waterSkill);

            if (clearBuffer != null)
            {
                StopCoroutine(clearBuffer);
            }

            inputBuffer.Clear();
            inputBuffer.Add(input);
            clearBuffer = StartCoroutine(ClearBufferAfterTime());
        }
    }
    private void AirHandler(InputAction.CallbackContext context)
    {
        ComboInput input = new ComboInput { key = "Air", time = Time.time };
        SkillData airSkill = FindSkill("Air");

        //Verificações de Falha
        if (airSkill == null)
        {
            Debug.Log("Skill Fire não encontrada.");
            return;
        }

        if (IsOnCoolDown("Fire", airSkill.coolDown))
        {
            Debug.Log("Fire ainda em cooldown.");
        }

        //Logica principal
        if (inputBuffer.Count > 0 && (Time.time - inputBuffer[0].time < comboWindow))
        {
            if (clearBuffer != null)
            {
                StopCoroutine(clearBuffer);
            }
            inputBuffer.Add(input);
            CheckForCombo();
            inputBuffer.Clear();
        }
        else
        {
            CastSimpleSkill(airSkill);

            if (clearBuffer != null)
            {
                StopCoroutine(clearBuffer);
            }

            inputBuffer.Clear();
            inputBuffer.Add(input);
            clearBuffer = StartCoroutine(ClearBufferAfterTime());
        }
    }
    private void EarthHandler(InputAction.CallbackContext context)
    {
        ComboInput input = new ComboInput { key = "Earth", time = Time.time };
        SkillData earthSkill = FindSkill("Earth");

        //Verificações de Falha
        if (earthSkill == null)
        {
            Debug.Log("Skill Fire não encontrada.");
            return;
        }

        if (IsOnCoolDown("Fire", earthSkill.coolDown))
        {
            Debug.Log("Fire ainda em cooldown.");
        }

        //Logica principal
        if (inputBuffer.Count > 0 && (Time.time - inputBuffer[0].time < comboWindow))
        {
            if (clearBuffer != null)
            {
                StopCoroutine(clearBuffer);
            }
            inputBuffer.Add(input);
            CheckForCombo();
            inputBuffer.Clear();
        }
        else
        {
            CastSimpleSkill(earthSkill);

            if (clearBuffer != null)
            {
                StopCoroutine(clearBuffer);
            }

            inputBuffer.Clear();
            inputBuffer.Add(input);
            clearBuffer = StartCoroutine(ClearBufferAfterTime());
        }
    }
    private void CastSimpleSkill(SkillData skill)
    {
        Debug.Log("Disparando habilidade " + skill.key1);
        cooldownTracker[skill.key1] = Time.time;
        //Implementar lógica na semana 2
    }
    
    private void CheckForCombo()
    {

        if (inputBuffer.Count >= 2)
        {
            ComboInput input1 = inputBuffer[inputBuffer.Count - 1];
            ComboInput input2 = inputBuffer[inputBuffer.Count - 2];
            if (input1.time - input2.time < comboWindow)
            {
                //Debug.Log("Combo detectado: " + input2.key + " + " + input1.key);
                Debug.Log(input1.time - input2.time);
                Debug.Log(FindComboRecipe(inputBuffer[0].key, inputBuffer[1].key).name);
                Instantiate(FindComboRecipe(inputBuffer[0].key, inputBuffer[1].key).comboEffectPrefab, MousePosition(), Quaternion.identity);
            }
            else if (input1.time - input2.time > comboWindow)
            {
                Debug.Log(input1.time - input2.time);
            }
            inputBuffer.Clear();
        }
    }
    private IEnumerator ClearBufferAfterTime()
    {
        yield return new WaitForSeconds(comboWindow);
        inputBuffer.Clear();
        Debug.Log("Buffer limpo por tempo");
    }
    private SkillData FindSkill(string key1)
    {
        foreach (var recipe in skillRecipes)
        {      
            if (key1 == recipe.key1)
            {
                return recipe;
            }
        }
        return null;
    }
    private ComboData FindComboRecipe(string key1, string key2)
    {
        foreach (var recipe in comboRecipes)
        {
            //para testar comutatividade, verifico ambas as condições
            bool match1 = (key1 == recipe.key1 && key2 == recipe.key2);
            bool match2 = (key1 == recipe.key2 && key2 == recipe.key1);
            if (match1 || match2)
            {
                return recipe;
            }
        }
        return null;
    }
    private Vector2 MousePosition()
    {
        Vector2 screenPosition = Input.mousePosition;
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    private bool IsOnCoolDown(string skillName, float cooldownDuration)
    {
        if (cooldownTracker.ContainsKey(skillName))
        {
            if (Time.time - cooldownTracker[skillName] < cooldownDuration)
            {
                Debug.Log(skillName+" em CoolDown");
                return true;
            }

        }
        return false;
    }

}
