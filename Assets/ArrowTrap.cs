using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
   [SerializeField] private float attackCooldown;
   [SerializeField] private Transform firePoint;
   [SerializeField] private GameObject[] arrows;
    private float cooldownTimer;
    private void Attack()
    {
        cooldownTimer = 0;

        Vector3 position = firePoint.position;
        arrows[Findarrow()].transform.position = position;
        arrows[Findarrow()].GetComponent<EnemyProjectile>().ActivateProjectile(); 
    }

    private int Findarrow()
    {
        for (int i = 0; i < arrows.Length; i++)  
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer>=attackCooldown)
        {
            Attack();
        }
    }



}
