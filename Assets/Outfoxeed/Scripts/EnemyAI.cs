﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    // Attack Vars
    public float attackRange = 0.75f;
    public float attackCooldown = 2.5f;
    protected float nextAttackTime = 0;
    public float secondActionRange = 2f;

    // Movements Vars
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 2f;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    //Death vars
    public GameObject deathParticles;
    public bool isDead;

    // Components vars
    Seeker seeker;
    protected Rigidbody2D rb;
    public Animator animator;

    // Action vars
    public Action AttackAction;
    public Action SecondAction;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        isDead = false;

        InvokeRepeating("UpdatePath", 0, 0.25f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone()) seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {
            bool canAttack = CanAttack();
            float distance = Vector2.Distance(target.position, transform.position);

            if (distance < attackRange)
            {
                if (canAttack) AttackAction?.Invoke();
            }
            else
            {
                ChasePlayer();
                if (distance < secondActionRange)
                {
                    if (canAttack) SecondAction?.Invoke();
                }
            }
        }
    }

    protected bool CanAttack() { return Time.time > nextAttackTime; }
    protected void SetNextAttackTime() { nextAttackTime = Time.time + attackCooldown; }

    protected void ChasePlayer()
    {
        animator.SetBool("isAttacking", false);
        if (path == null) return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        rb.AddForce(direction * speed * Time.deltaTime);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance) currentWaypoint++;
    }
    public void OnDeath()
    {
        rb.velocity = Vector3.zero;
        GetComponent<CircleCollider2D>().enabled = false;
        GameObject particles = Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(particles, 5f);
        animator.SetBool("isDead", true);
        GameHandler.instance.RemoveAliveEnemyToCounter();
        isDead = true;
        Destroy(gameObject, 5f);
    }

    #region MonobehaviourMethods

    private void OnBecameVisible()
    {
        GameHandler.instance.AddScreenVisibleEnemyToCounter();
    }
    private void OnBecameInvisible()
    {
        GameHandler.instance.RemoveScreenVisibleEnemyToCounter();
    }
    #endregion
}
