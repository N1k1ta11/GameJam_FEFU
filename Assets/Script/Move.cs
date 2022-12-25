using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpForce = 15f; //сила прыжка

    public static Move Instance { get; set; }

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public enum States
    {
        Stay,
        Run
    }

    public bool dance;

    private States State
    {
        get { return (States)anim.GetInteger("Speed"); }
        set { anim.SetInteger("Speed", (int)value); }
    }

    private bool StateJ
    {
        get { return anim.GetBool("Jump"); }
        set { anim.SetBool("Jump", value); }
    }

    public void GetDamage()
    {
        lives -= 1;
        Debug.Log(lives);
    }


    private void Run()
    {
        if (isGrounded)
            State = States.Run;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 1f);
        isGrounded = collider.Length > 1;

        if (!isGrounded)
            StateJ = true;
        else
            StateJ = false;

    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (dance)
        {
            anim.SetBool("Dance", dance);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isGrounded)
            State = States.Stay;

        if (Input.GetButton("Horizontal"))
            Run();
        else if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();

    }
}