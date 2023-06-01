using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

     GameObject player;
    float distToPlayer;
    public float speed;
    public int maxHealth;
    public int health;



    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        distToPlayer = Vector2.Distance(transform.position, player.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*0.1f*Time.deltaTime);



        if (health == 0)
        {
            Destroy(gameObject);
        }

        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            health--;
        }
    }

}
