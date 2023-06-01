using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public static int health;
    public int maxHealth;
    public bool hasShield;

    
    Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (health == 0)
        {
            Destroy(gameObject);
        }

        



    }

    private void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        Vector2 lookDir = mousePos - rb.position;
        BallControl.mousePos = lookDir;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            print(health);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (BallControl.notMoving)
        {
            BallControl.holdBall = true;
        }
    }


}
