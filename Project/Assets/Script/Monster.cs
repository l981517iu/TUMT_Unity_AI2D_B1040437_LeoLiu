using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [Range(0,100)]
    public float speed = 1.5f;
    [Range(0,100)]
    public float damage = 10;

    public float playerdamage = 20;

    public float hp = 100;

    public Transform checkPoint;
    private Rigidbody2D r2d;

    private void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Dead();
        Debug.Log(hp);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(checkPoint.position, -checkPoint.up * 1.5f);
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Player1")
        {
            Track(collision.transform.position);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "damage1")
        {
            hp -= playerdamage;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1")
        {
            collision.gameObject.GetComponent<Player1Single>().Damage(damage);
        }
    }


    private void Move()
    {
        r2d.AddForce(-transform.right * speed);

        RaycastHit2D hit = Physics2D.Raycast(checkPoint.position, -checkPoint.up, 1.5f, 1 << 8);

        if(hit == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    private void Track(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void Dead()
    {
        if(hp<= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
