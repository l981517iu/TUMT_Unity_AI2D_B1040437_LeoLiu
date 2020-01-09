using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Player1Single : MonoBehaviour
{
    public int speed = 50;
    public float jump = 2.5f;
    public string player1Name = "Player1";

    public bool isGround = false;

    public UnityEvent onEat;

    private Rigidbody2D r2d;
    private Animator anim;

    public float cooldownTime = 1f;
    private float nextFireTime = 0f;

    public GameObject target;
    public GameObject firePoint;

    public float hp = 100;
    private float hpMax;
    public Image hpBar;
    

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

        if (Input.GetKeyDown(KeyCode.A)) TurnLeft();
        if (Input.GetKeyDown(KeyCode.D)) TurnRight();

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
        
        if (collision.tag == "outline")
        {
            hp -= 999;

        }

        if (collision.tag == "key")
        {
            Destroy(collision.gameObject);
            onEat.Invoke();
            winorlost.GetComponent<WOL>().Player1Win();
        }
    }

    private void Walk()
    {
        r2d.AddForce(new Vector2(speed * Input.GetAxis("Horizontal"), 0));
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
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
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            r2d.AddForce(new Vector2(0, jump));
            anim.SetTrigger("jump");
        }
    }

    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpMax;
    }

    private void Attack()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetTrigger("attack");
                Instantiate(target, firePoint.transform.position, transform.rotation);

                nextFireTime = Time.time + cooldownTime;

            }
        }
    }

    private void Dead()
    {
        if (hp <= 0)
        {
            anim.SetBool("dead", true);
            speed = 0;
            jump = 0;
            
            winorlost.GetComponent<WOL>().Player2Lose();
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