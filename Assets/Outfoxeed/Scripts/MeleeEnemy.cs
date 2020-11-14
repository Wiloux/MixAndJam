using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyAI
{
    public float dashForce = 500f;
    private void Awake()
    {
        AttackAction = Hit;
        SecondAction = Dash;
    }
    void Hit()
    {
        Debug.Log("Attack");
        animator.SetBool("isAttacking", true);
        // Set time for next attack
        SetNextAttackTime();
    }

    void Dash()
    {
        // Dash
        rb.AddForce((target.position - transform.position).normalized * dashForce, ForceMode2D.Impulse);
        // Attack
        AttackAction();
    }
}