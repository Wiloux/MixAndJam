using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 dir;
    public float spd;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * spd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if (!collision.GetComponent<EnemyAI>().isDead)
            {
                CameraScript.instance.shakeDuration = 0.1f;
                collision.GetComponent<EnemyAI>().OnDeath();
            }
        }

        if(collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
