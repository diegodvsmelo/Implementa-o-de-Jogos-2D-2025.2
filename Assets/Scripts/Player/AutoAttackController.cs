using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class AutoAttackController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private bool isShooting = true;
    public float coolDownShoot;
    public Vector2 directionNormalized;
    void Start()
    {
        StartCoroutine(FireRoutine());
    }
    void Update() 
    {
        
    }
    IEnumerator FireRoutine()
    {
        while (isShooting)
        {
            float closestDistance = float.PositiveInfinity;
            EnemyAI closestEnemy = null;
            foreach (var enemy in EnemyManager.allEnemies)
            {
                float enemyDistance = Vector2.Distance(this.gameObject.transform.position, enemy.transform.position);
                if(enemyDistance < closestDistance)
                {
                    closestDistance = enemyDistance;
                    closestEnemy = enemy.GetComponent<EnemyAI>();
                }
            }
            
            if(closestEnemy != null && closestDistance<8f)
            {
                GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

                Vector2 direction = closestEnemy.transform.position - transform.position;
                directionNormalized = direction.normalized;
                
                newProjectile.GetComponent<ProjectileMovement>().Setup(directionNormalized);
            }
            yield return new WaitForSeconds(coolDownShoot);
        }
    }
}
