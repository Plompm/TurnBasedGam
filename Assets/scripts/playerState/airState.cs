using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class airState : MonoBehaviour
{
    Image[] _crosshairs;
    GameObject FlameThrower;

    void Start()
    {
        _crosshairs = GetComponentsInChildren<Image>();
        for (int i = 0; i < _crosshairs.Length; i++)
        {
            _crosshairs[i].color = Color.white;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //primary Attack
        if (Input.GetMouseButtonDown(0))
        {
            
        }
        //secondary Attack
        if (Input.GetMouseButtonDown(1))
        {

        }
    }
}
