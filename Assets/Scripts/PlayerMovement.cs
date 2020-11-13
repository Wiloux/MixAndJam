using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    Vector3 tempVect;

    public int maxwpn;
    int currentwpn;

    public GameObject bulletGameObject;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    float x;
    float y;

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        tempVect = new Vector3(x, y, 0);
        tempVect = new Vector2(tempVect.x, tempVect.y).normalized;
        if (Input.GetMouseButtonDown(1))
        {
            currentwpn++;
        }
    }

    private void FixedUpdate()
    {
        if (x != 0 || y != 0)
        {
            rb.velocity = new Vector2(tempVect.x * speed, tempVect.y * speed);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }


    public void ChooseAttackType()
    {
        switch (currentwpn % maxwpn)
        {
            case 1:
                OnKickShoot();
                break;
            case 0:
                OnKickSword();
                break;
        }
    }
    public GameObject Slash;
    public float SlashTime;

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

    public void OnPlayerDeath()
    {

    }
}
