using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PastLevel : MonoBehaviour
{
    private int scenNum;
    public Transform player;
    private void Check()
    {
        float distToPlayerY = Mathf.Abs(transform.position.y - player.position.y);
        float distToPlayerX = Mathf.Abs(transform.position.x - player.position.x);
        // Debug.Log("Distance Y= "+distToPlayerY + " Distance X = "+distToPlayerX);
        if ((int)distToPlayerY < 1.7 && distToPlayerX < 1.7)
        {
            Debug.Log("Distance Y= " + distToPlayerY + " Distance X = " + distToPlayerX);
            SceneManager.LoadScene(scenNum - 1);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        scenNum = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        Check();
    }
}
