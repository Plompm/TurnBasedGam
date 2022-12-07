using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceLookAt : MonoBehaviour
{
    GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform);
    }
}
