using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject wall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Block"))
        {
            wall.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Block"))
        {
            wall.SetActive(true);
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
