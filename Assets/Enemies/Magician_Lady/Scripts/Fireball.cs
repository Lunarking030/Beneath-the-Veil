using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f; // speed of the fireball
    public int damage = 10; // amount of damage the fireball does to the player

    private Transform target; // the player object
    private Vector3 direction; // the direction the fireball will travel

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; // find the player object
        direction = (target.position - transform.position).normalized; // calculate the direction to the player
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime); // move the fireball in the calculated direction

        // if the fireball goes offscreen, destroy it
        if (transform.position.y < -10f || transform.position.y > 10f || transform.position.x < -10f || transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage); // call the TakeDamage function in the Player script
            Destroy(gameObject); // destroy the fireball on impact with the player
        }
    }
}
