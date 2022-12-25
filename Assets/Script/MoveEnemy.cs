using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;
    private SpriteRenderer sprite;

    public float speed;
    public float agroDistance = 0;

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
            //physic.velocity = new Vector2(-speed, 0);
            sprite.flipX = true;
        }
        else if (player.position.x > transform.position.x)
        {
            Vector3 dir = transform.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            //physic.velocity = new Vector2(speed, 0);
            sprite.flipX = false;
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

        if (distToPlayer > agroDistance)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }
    }
}