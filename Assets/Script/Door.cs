using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointTeleport;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Block"))
        {
            collision.gameObject.transform.position = pointTeleport.transform.position + new Vector3(2, 0, 0);
            Debug.Log("Teleport");
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
