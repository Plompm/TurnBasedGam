using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceCicle : MonoBehaviour
{
    bool _hasBeenShot;
    Rigidbody _rb;
    float _timer;
    bool _timerStarted;

    private void Awake()
    {
        _hasBeenShot = false;
        _rb = gameObject.GetComponent<Rigidbody>();
        _timerStarted = false;
    }

    public void OnSpawn(Transform parent)
    {
        transform.parent = parent;
    }
    public void OnShot()
    {
        transform.parent = null;
        _hasBeenShot = true;
        _timerStarted = true;
        _timer = Time.time + 3;
    }

    private void FixedUpdate()
    {
        if (_hasBeenShot == true)
        {
            _rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 50);
        }
    }

    private void Update()
    {
        if (_timerStarted == true && _timer <= Time.time)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("Cold Death");
        }
    }
}
