using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private bool isShooting = true;
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
            GameObject[] allenemies = GameObject.FindGameObjectsWithTag("Enemy");
            yield return new WaitForSeconds(2.0f);
        }
    }
}
