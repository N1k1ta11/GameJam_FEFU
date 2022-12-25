using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Triger : MonoBehaviour
{
    public int scenNum;
    public Transform player;
    private void CheckFinish()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distance = "+distToPlayer);
        if(distToPlayer <2)
        {
            SceneManager.LoadScene(scenNum+1);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckFinish();
    }
}
