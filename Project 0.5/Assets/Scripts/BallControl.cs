using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public static bool notMoving;
    public float speed;
    Rigidbody2D rb;
    float currentSpeed;
    public float minSpeed;
    
    public static bool holdBall = true;
    public Transform ballHolder;


    /*public Camera cam;*/
    public static Vector2 mousePos;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb= GetComponent<Rigidbody2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (holdBall)
        {
            transform.position = ballHolder.position;
            /*mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.Normalize();*/
        }        

        if (Input.GetMouseButtonDown(0) && holdBall)
        {
            holdBall = false;
            mousePos.Normalize();
            rb.velocity = mousePos * speed * Time.deltaTime;
            notMoving = false;
        }

        currentSpeed = rb.velocity.magnitude;
        
        if (currentSpeed <= minSpeed)
        {
            notMoving = true;
        }
        


    }

    




}
