using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireState : MonoBehaviour
{
    Image[] _crosshairs;
    GameObject _flameThrower;
    GameObject _camera;
    Vector3 _spawnPos;

    void Start()
    {
        _crosshairs = GetComponentsInChildren<Image>();
        for (int i = 0; i < _crosshairs.Length; i++)
        {
            _crosshairs[i].color = Color.red;
        }

        _flameThrower = gameObject.GetComponent<PlayerManager>().FlameThrower;
        _camera = Camera.main.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //primary Attack
        if (Input.GetMouseButtonDown(0))
        {
            _spawnPos = new Vector3(_camera.transform.position.x, _camera.transform.position.y - 0.5f, _camera.transform.position.z);
            Instantiate(_flameThrower, _spawnPos, _camera.transform.rotation, _camera.transform);
        }
        //secondary Attack
        if (Input.GetMouseButtonDown(1))
        {
           
        }
    }
}
