using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update

    bool moveing = true;
    public float rightX;
    public float leftX;
    float speed = 2f;

    private void CheckPos()
    {
        if ((int)transform.position.x == (int)rightX)
        {
            moveing = true;
        }
        else if((int)transform.position.x == (int)leftX)
        {
            moveing = false;
        }
    }

    private void FixedUpdate()
    {
        CheckPos();
        if(moveing)
        {
            transform.position = new Vector2(transform.position.x+Time.fixedDeltaTime*speed, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - Time.fixedDeltaTime * speed, transform.position.y);
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
