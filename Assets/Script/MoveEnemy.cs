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
        if(player.position.x < transform.position.x) { //бот пойдёт влево
            physic.velocity = new Vector2(-speed, 0);
            //transform.localScale = new Vector2((float)0.040168, (float)0.1713982);
            sprite.flipX = true;
        }
        else if(player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(speed, 0);
            sprite.flipX = false;
            //transform.localScale = new Vector2((float)-0.040168, (float)0.1713982);
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

        if(distToPlayer > agroDistance)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }
    }
}
