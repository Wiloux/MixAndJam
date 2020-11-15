using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 dir;
    public float spd;
    public Rigidbody2D rb;
    CameraScript camscript;

    private void Start()
    {
        camscript = Camera.main.GetComponent<CameraScript>();
        rb = GetComponent<Rigidbody2D>();
        Quaternion PointerQ = Quaternion.LookRotation(Vector3.forward, dir);
        transform.rotation = PointerQ;
        rb.velocity = dir * spd;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (collision.GetComponent<EnemyAI>() != null && !collision.GetComponent<EnemyAI>().isDead)
            {
                camscript.shakeDuration = 0.1f;
                collision.GetComponent<EnemyAI>().OnDeath();
            }
        }

        if (collision.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
