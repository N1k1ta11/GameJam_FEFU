using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;
    private SpriteRenderer sprite;
    private Animator anim;

    public int lives;
    public float speed=3f;
    public float activeDist=1000;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        physic = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //bool stad;
    private void StartHunting()
    {

        if (player.position.x < transform.position.x && ((int)player.position.y <= (int)transform.position.y + activeDist ) && ((int)player.position.y >= (int)transform.position.y - activeDist))
        {
            stad = true;
            Vector3 dir = transform.right * (-1);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            sprite.flipX = true;
        }
        else if (player.position.x > transform.position.x && ((int)player.position.y <= (int)transform.position.y + activeDist) && ((int)player.position.y >= (int)transform.position.y - activeDist))
        {
            stad = true;
            Vector3 dir = transform.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
            sprite.flipX = false;
        }
    }

    private bool stad
    {
        get { return anim.GetBool("walk"); }
        set { anim.SetBool("walk", value); }
    }

    private void StopHunting()
    {
        stad = false;
        physic.velocity = new Vector2(0, 0); //Xyenzov
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayerY = Mathf.Abs(transform.position.y - player.position.y);
        float distToPlayerX = Mathf.Abs(transform.position.x - player.position.x);
        if (distToPlayerY < activeDist || distToPlayerX<activeDist)
        {
            
            StartHunting();

        }
        else
        {
            StopHunting();
        }
    }
}
