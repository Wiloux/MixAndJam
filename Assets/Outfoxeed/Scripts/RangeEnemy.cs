using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : EnemyAI
{
    public GameObject projectilePrefab;
    private void Awake()
    {
        AttackAction = GetPlayerInsight;
        SecondAction = null;
    }
    void GetPlayerInsight()
    {
        Vector2 targetDir = (target.position - transform.position).normalized;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, targetDir, attackRange);
        if (hit.transform.CompareTag("Player")){Shoot(targetDir);}
        else ChasePlayer();
    }
    void Shoot(Vector2 direction)
    {
        Debug.Log("Shoot");
        animator.SetBool("isAttacking", true);
        // Set time for next attack
        SetNextAttackTime();

        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<EnemyBullet>().dir = direction;
    }
}
