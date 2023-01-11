using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rest : MonoBehaviour
{
    private int numScen;
    private bool ok=true;
    private void CheckDie()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 20f);
        ok = collider.Length > 1;
    }

    private void FixedUpdate()
    {
        CheckDie();
    }

    // Start is called before the first frame update
    void Start()
    {
        numScen = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ok)
        {
            SceneManager.LoadScene(numScen);
        }
    }
}
