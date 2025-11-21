using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static List<EnemyAI> allEnemies;
    void Awake()
    {
        allEnemies = new List<EnemyAI>();
    }
}
