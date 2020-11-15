using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    CameraScript camscript;
    private void Start()
    {
      camscript = Camera.main.GetComponent<CameraScript>();
    }
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!collision.GetComponent<EnemyAI>().isDead)
            {
              camscript.shakeDuration = 0.1f;
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
                camscript.shakeDuration = 0.1f;
                collision.GetComponent<EnemyAI>().OnDeath();
            }
        }
    }
}
