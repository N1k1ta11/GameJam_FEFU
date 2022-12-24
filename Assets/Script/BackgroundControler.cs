using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundControler : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 pos;

    private void Awake()
    {
        if(!_player)
            _player = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        pos = _player.position;
        pos.z = -10;
        pos.y = 0;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime); ;
    }
}
