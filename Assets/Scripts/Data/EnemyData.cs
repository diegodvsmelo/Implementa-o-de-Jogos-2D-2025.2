using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Game/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Stats")]
    public float moveSpeed;
    public int maxHealth;
    public int damage;
    public int exp;
    public GameObject enemyPrefab;
}
