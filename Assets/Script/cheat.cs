using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cheat : MonoBehaviour
{
    private int scenNum;
    private void CheckFinish()
    {
        if(Input.GetKeyUp(KeyCode.Alpha0) && scenNum <= 14)
        {
            SceneManager.LoadScene(scenNum+1);
        }
        if(Input.GetKeyUp(KeyCode.Alpha9) && scenNum >=0)
        {
            SceneManager.LoadScene(scenNum-1);
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
        CheckFinish();
    }
}
