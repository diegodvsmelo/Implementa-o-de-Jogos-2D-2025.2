using UnityEngine;

public enum SkillBehaviorType
{
    projectile,
    orbiting,
    groundArea,
    aoe
}
//para adicionar a opção no menu Assets> Create> Game> ComboRecipe
[CreateAssetMenu(fileName = "NewSkill", menuName = "Game/SimpleSkill")]
public class SkillData : ScriptableObject
{
    public string key1;
    public GameObject effectPrefab;
    public float coolDown;

    public SkillBehaviorType behaviorType;
}