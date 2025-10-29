using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
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
            Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;
            Vector2 spawnPosition = (Vector2)playerTransform.position + (randomDirection * spawnDistance);
            Instantiate(enemyPrefab, spawnPosition, quaternion.identity);
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
