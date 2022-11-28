using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earthDisk : MonoBehaviour
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
        transform.rotation = Camera.main.transform.rotation;
        if (Vector3.Distance(Camera.main.transform.position, transform.position) >= 12)
        {
            print("out of range");
        }
    }

    void DestroyByTime()
    {
        if (_timer <= Time.time)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= -0.2f)
        {
            _rb.MovePosition(transform.position + transform.up * Time.deltaTime * 12);
        }

        if (_throwWall == true)
        {
            _rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 60);
        }
    }
    public void OnThrow()
    {
        _rb.useGravity = true;
        _throwWall = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("CRUMBLE");
        }
    }

    void outOfRange()
    { 
        
    }
}
