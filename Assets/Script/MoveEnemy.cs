using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;


public class MoveEnemy : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;
    private SpriteRenderer sprite;
    private Animator anim;

    public float speed;
    private float agroDistance = 0;
    public float activeDist;

    private bool stad
    {
        get { return anim.GetBool("WALK"); }
        set { anim.SetBool("WALK", value); }
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        physic = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void StartHunting()
    {
        
        if (player.position.x < transform.position.x && ((int)player.position.y == (int)transform.position.y+2 || (int)player.position.y == (int)transform.position.y))
        {
            stad = true;
            Vector3 dir = transform.right * (-1);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            sprite.flipX = true;
        }
        else if (player.position.x > transform.position.x && ((int)player.position.y == (int)transform.position.y + 2 || (int)player.position.y == (int)transform.position.y))
        {
            stad = true;
            Vector3 dir = transform.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            sprite.flipX = false;
        }
    }

    private void StopHunting()
    {
        stad = false;
        physic.velocity = new Vector2(0, 0); //Xyenzov
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