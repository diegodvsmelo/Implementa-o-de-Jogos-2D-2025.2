using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyBasePrefab;
    public List<EnemyData> enemyTypesToSpawn;
    public float coolDownSpawn;
    [SerializeField] private float spawnDistance = 15f;
    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int index = Random.Range(0, enemyTypesToSpawn.Count);
            EnemyData dataToSpawn = enemyTypesToSpawn[index];

            Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;
            Vector2 spawnPosition = (Vector2)playerTransform.position + (randomDirection * spawnDistance);



            GameObject newEnemy = Instantiate(dataToSpawn.enemyPrefab, spawnPosition, Quaternion.identity);
            newEnemy.GetComponent<EnemyAI>().Initialize(dataToSpawn);
            newEnemy.GetComponent<EnemyHealth>().Initialize(dataToSpawn);
            yield return new WaitForSeconds(coolDownSpawn);
        }

    }
    void OnDrawGizmos()
    {
        if (playerTransform != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(playerTransform.position, spawnDistance);
        }
        
    }
}
