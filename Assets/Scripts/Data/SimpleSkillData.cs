using UnityEngine;

//para adicionar a opção no menu Assets> Create> Game> ComboRecipe
[CreateAssetMenu(fileName = "NewSkill", menuName = "Game/SimpleSkill")]

public class SkillData : ScriptableObject
{
    public string key1;
    public GameObject comboEffectPrefab;
    public float coolDown;
}