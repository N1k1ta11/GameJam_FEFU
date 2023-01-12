using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillBoss : MonoBehaviour
{
    // Start is called before the first frame update

    public int lives = 3;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block")
        {
            Debug.Log("Collis");
            Destroy(collision.gameObject);
            lives--;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
