using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyEngine : MonoBehaviour
{
     GameObject player;
    float distToPlayer;
    public float speed;
    public int maxHealth;
    public int health;


    public GameObject bullet;
    public float cooldown;
    float nextShotTime;

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
        EneBullEngine.direction = direction;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer > 8)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * 0.1f * Time.deltaTime);
        }
        if (distToPlayer < 3.5)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, -speed * 0.1f * Time.deltaTime);
        }
        

        if (Time.time > nextShotTime)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextShotTime = Time.time + cooldown;
            int randomDir = Random.Range(-1, 1);
            
        }


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
