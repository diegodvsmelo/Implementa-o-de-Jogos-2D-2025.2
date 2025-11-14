using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewWave", menuName = "Game/EnemyWave")]
public class WaveData: ScriptableObject
{
    [Header("Início da Wave")]
    public float timeInSecToStart;

    [Header("Inimigos da Wave")]
    public List<EnemyData> enemyPool;

    [Header("Cooldown do Spawn")]
    public float cooldownBetweenSpawn;
}