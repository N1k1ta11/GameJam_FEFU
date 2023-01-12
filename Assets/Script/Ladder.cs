using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private float vertical;
    private float speed = 8f;
    private bool isLadder;
    private bool isClimping;
    
    [SerializeField] private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder= true;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimping = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Ladder")
        {
            if (Input.GetKey(KeyCode.S))
            {
                rb.velocity = rb.velocity = new Vector2(rb.velocity.x, -speed);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }
    //public Transform ledd;
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimping = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimping)
        {
            rb.gravityScale = 0;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
}
