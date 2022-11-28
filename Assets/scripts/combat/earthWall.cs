using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthWall : MonoBehaviour
{
    Rigidbody _rb;
    bool _throwWall;
    float _timer;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _throwWall = false;
    }

    private void Start()
    {

        _timer = Time.time + 5f;
    }

    private void Update()
    {
        DestroyByTime();
    }

    void DestroyByTime()
    {
        if (_timer <= Time.time)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= 0.8f)
        {
            _rb.MovePosition(transform.position + transform.up * Time.deltaTime * 8);
        }

        if (_throwWall == true)
        {
            _rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 20);
        }
    }
    public void OnThrow()
    {
        _throwWall = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("CRUNCH");
        }
    }
}
