using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scen : MonoBehaviour
{
    public void LoadScene(int sceneid)
    {
        //Debug.Log("Ты нажал");
        SceneManager.LoadScene(sceneid);
    }

    public void QuitGame()
    {
       // Debug.Log("Exit");
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
