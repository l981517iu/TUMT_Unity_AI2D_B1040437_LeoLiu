using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Script : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string player1Name = "Player2";

    public bool isGround = false;

    private Rigidbody2D r2d;
    private Animator anim;

    public float cooldownTime = 1f;
    private float nextFireTime = 0f;

    public GameObject target;
    public GameObject firePoint;

    public float hp = 100;
    private float hpMax;
    public Image hpBar;
    public int damage = 20;

    public GameObject winorlost;


    // Start is called before the first frame update
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hpMax = hp;
        target.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hp);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) TurnLeft();
        if (Input.GetKeyDown(KeyCode.RightArrow)) TurnRight();
    }

    private void FixedUpdate()
    {
        Walk();
        Jump();
        Attack();
        Dead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "damage1")
        {
            hp -= damage;
            hpBar.fillAmount = hp / hpMax;
            
        }
    }

    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("ArrowHorizontal"), 0));
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("walk", true);
            anim.SetBool("idle", false);
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("idle", true);
        }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.RightControl) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
            anim.SetTrigger("jump");
        }
    }

    private void Attack()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                anim.SetTrigger("attack");
                Instantiate(target, firePoint.transform.position, transform.rotation);

                nextFireTime = Time.time + cooldownTime;

            }
        }
    }

    private void Dead()
    {
        if(hp <= 0)
        {
            anim.SetBool("dead", true);
            speed = 0;
            jump = 0;
            winorlost.GetComponent<WinOrLost>().Player2Dead();
            target.SetActive(false);

        }
    }

    private void TurnRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void TurnLeft()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
}
