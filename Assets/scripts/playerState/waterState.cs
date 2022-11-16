using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterState : MonoBehaviour
{
    Image[] _crosshairs;

    void Start()
    {
        _crosshairs = GetComponentsInChildren<Image>();
        for (int i = 0; i < _crosshairs.Length; i++)
        {
            _crosshairs[i].color = Color.cyan;
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
