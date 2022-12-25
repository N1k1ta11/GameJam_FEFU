using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveEnemy : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;
    private SpriteRenderer sprite;

    public float speed;
    private float agroDistance = 0;
    public float activeDist;



    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        physic = GetComponent<Rigidbody2D>();
    }

    private void StartHunting()
    {
        if (player.position.x < transform.position.x)
        {
            Vector3 dir = transform.right * (-1);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            sprite.flipX = false;
        }
        else if (player.position.x > transform.position.x)
        {
            Vector3 dir = transform.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            sprite.flipX = true;
        }
    }

    private void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        if (distToPlayer > agroDistance && distToPlayer < activeDist)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }
    }
}