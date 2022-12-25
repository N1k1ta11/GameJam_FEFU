using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Transform _player;
    private Vector3 pos;

    private void Awake()
    {
        if (!_player)
        {
            _player = FindObjectOfType<Move>().transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

=======
    public Camera cam;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
>>>>>>> 7b14d062293566d953a11784857bc334a00192db
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        pos = _player.position;
        pos.z = -10f;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }
}
=======
        
    }
}
>>>>>>> 7b14d062293566d953a11784857bc334a00192db
