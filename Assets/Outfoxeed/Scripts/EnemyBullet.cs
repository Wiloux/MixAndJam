using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Vector2 dir;
    public float spd;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = dir * spd;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        // Tuer joueur
    //    }

    //    if (collision.tag != "Ennemy")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
