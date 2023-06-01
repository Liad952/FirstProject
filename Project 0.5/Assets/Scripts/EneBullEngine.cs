using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneBullEngine : MonoBehaviour
{

    public static Vector2 direction;
    public float speed = 2;
    public Vector2 velocity;

    private void Start()
    {
        velocity = direction * speed;
    }


    private void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos += velocity * Time.deltaTime;
        transform.position = pos;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            Destroy(gameObject);
            PlayerController.health--;
        }
    }

}
