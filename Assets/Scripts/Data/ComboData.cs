using UnityEngine;

//para adicionar a opção no menu Assets> Create> Jogo> Receita de Combo
[CreateAssetMenu(fileName = "NovoCombo", menuName = "Jogo/Receita de Combo")]

public class ComboData : ScriptableObject
{
    public string key1;
    public string key2;

    public GameObject comboEffectPrefab;
    public float coolDown;
}
