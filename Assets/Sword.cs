using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!collision.GetComponent<EnemyAI>().isDead)
            {
                CameraScript.instance.shakeDuration = 0.1f;
                collision.GetComponent<EnemyAI>().OnDeath();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!collision.GetComponent<EnemyAI>().isDead)
            {
                CameraScript.instance.shakeDuration = 0.1f;
                collision.GetComponent<EnemyAI>().OnDeath();
            }
        }
    }
}
