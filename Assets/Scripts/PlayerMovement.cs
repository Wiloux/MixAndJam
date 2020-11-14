using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    public bool isDead;
    public GameObject deathParticles;
    public float speed;
    Vector3 tempVect;

    public int maxwpn;
    int currentwpn;

    public GameObject bulletGameObject;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //musicSource = GetComponent<AudioSource>();
        //  musicSource.Play();
    }

    float x;
    float y;



    //the total number of loops completed since the looping clip first started
  //  public int completedLoops = 0;

    //The current position of the song within the loop in beats.
    public float loopPositionInBeats;

    public float loopPositionInAnalog;

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            x = Input.GetAxisRaw("Horizontal");
            y = Input.GetAxisRaw("Vertical");
            tempVect = new Vector3(x, y, 0);
            tempVect = new Vector2(tempVect.x, tempVect.y).normalized;
            //if (Input.GetMouseButtonDown(1))
            //{
            //    currentwpn++;
            //}

            if (Input.GetMouseButtonDown(0) && !isDashing)
            {
                Dash();
            }
        }

        //if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
        //    completedLoops++;

     //   loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;



    }



    private void FixedUpdate()
    {
        if (x != 0 || y != 0)
        {
            rb.velocity = new Vector2(tempVect.x * speed, tempVect.y * speed);
        }
        else
        {
            if (!isDashing)
            {
                rb.velocity = Vector3.zero;
            }
        }

        if (isDead) { rb.velocity = Vector3.zero; }
    }


    public void ChooseAttackType(int i)
    {
        if (!isDead)
        {
            switch (i)
            {
                case 1:
                    OnKickShoot();
                    break;
                case 0:
                    OnKickSword();
                    break;
            }
        }
    }
    public GameObject Slash;
    public float SlashTime;

    public float DashForce;
    public float DashTime;
    public bool isDashing;

    void Dash()
    {
        StartCoroutine(DashCoro());
    }

    IEnumerator DashCoro()
    {
        rb.AddForce(tempVect.normalized * DashForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(DashTime);
        isDashing = false;
    }

    void OnKickShoot()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = transform.position - MousePos;
        GameObject bullet = Instantiate(bulletGameObject, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().dir = -dir.normalized;
    }

    void OnKickSword()
    {
        StartCoroutine(SlashCoro());
    }

    IEnumerator SlashCoro()
    {
        float time = 0;
        while (time <= 1f)
        {
            Slash.SetActive(true);
            Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = transform.position - MousePos;
            Quaternion PointerQ = Quaternion.LookRotation(Vector3.forward, -direction);
            //PointerQ.y = -PointerQ.y;
            //  Vector3 North = new Vector3(0, 0, GameObject.FindGameObjectWithTag("MainCamera").transform.eulerAngles.y);
            Slash.transform.rotation = PointerQ;
            time += Time.deltaTime / SlashTime;
            yield return null;
        }
        Slash.SetActive(false);
    }

    public AudioClip death;
    public void OnPlayerDeath()
    {
        rb.velocity = Vector3.zero;
        GetComponent<Collider2D>().enabled = false;
        GameObject particles = Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(particles, 5f);
        anim.SetBool("isDead", true);
        GetComponent<AudioSource>().PlayOneShot(death);
        Camera.main.GetComponent<AudioSource>().Stop();
        GameHandler.instance.DisplayGameOver();
        isDead = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            OnPlayerDeath();
        }
    }
}
