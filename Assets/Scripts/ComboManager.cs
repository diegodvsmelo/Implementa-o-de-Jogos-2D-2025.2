using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ComboManager : MonoBehaviour
{
    private InputActions controls;

    public List<ComboData> comboRecipes = new List<ComboData>();
    private List<ComboInput> inputBuffer = new List<ComboInput>();
    public float comboWindow = 300f;

    private struct ComboInput
    {
        public string key;
        public float time;
    }

    void Awake()
    {
        controls = new InputActions();
    }

    void OnEnable()
    {
        controls.PlayerControls.Enable();
        controls.PlayerControls.Fire.performed += HandleFire;
        controls.PlayerControls.Water.performed += HandleWater;
        controls.PlayerControls.Air.performed += HandleAir;
        controls.PlayerControls.Earth.performed += HandleEarth;
    }
    void OnDisable()
    {
        controls.PlayerControls.Disable();
        controls.PlayerControls.Fire.performed -= HandleFire;
        controls.PlayerControls.Water.performed -= HandleWater;
        controls.PlayerControls.Air.performed -= HandleAir;
        controls.PlayerControls.Earth.performed -= HandleEarth;
    }
    private void HandleFire(InputAction.CallbackContext context)
    {
        ComboInput input = new ComboInput { key = "Fire", time = Time.time };
        inputBuffer.Add(input);
        CheckForCombo();
    }

    private void HandleWater(InputAction.CallbackContext context)
    {
        ComboInput input = new ComboInput { key = "Water", time = Time.time };
        inputBuffer.Add(input);
        CheckForCombo();
    }

    private void HandleAir(InputAction.CallbackContext context)
    {
        ComboInput input = new ComboInput { key = "Air", time = Time.time };
        inputBuffer.Add(input);
        CheckForCombo();
    }

    private void HandleEarth(InputAction.CallbackContext context)
    {
        ComboInput input = new ComboInput { key = "Earth", time = Time.time };
        inputBuffer.Add(input);
        CheckForCombo();
    }

   private void CheckForCombo()
    {   
        if(inputBuffer.Count>=2)
        {
            ComboInput input1 = inputBuffer[inputBuffer.Count-1];
            ComboInput input2 = inputBuffer[inputBuffer.Count - 2];
            if (input1.time - input2.time < comboWindow)
            {
                Debug.Log("Combo detectado: " + input2.key + " + " + input1.key);
                foreach (var recipe in comboRecipes)
                {
                    //para testar comutatividade, verifico ambas as condições
                    bool match1 = (input1.key == recipe.key1 && input2.key == recipe.key2);
                    bool match2 = (input1.key == recipe.key2 && input2.key == recipe.key1);

                    if(match1||match2)
                    {
                        Vector2 screenPosition = Input.mousePosition;
                        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
                        Debug.Log("Combo encontrado: " + recipe.name);
                        Instantiate(recipe.comboEffectPrefab, worldPosition, quaternion.identity);
                        break;
                    }
                }
            }
            else
            {
                Debug.Log("Sem combo, habilidade simples lançada" + input1.key);
            }
            inputBuffer.Clear();
        }
    }
}
