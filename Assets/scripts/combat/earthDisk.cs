using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class earthDisk : MonoBehaviour
{
    Rigidbody _rb;
    bool _throwDisk;
    float _timer;
    bool _canControll;
    GameObject _spawner;
    bool _justLeftRange;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _throwDisk = false;
        _canControll = true;
        _justLeftRange = false;
    }

    private void Start()
    {

        _timer = Time.time + 5f;
    }

    private void Update()
    {
        DestroyByTime();
        if (_canControll == true)
        {
            transform.rotation = Camera.main.transform.rotation;
        }
        if (Vector3.Distance(Camera.main.transform.position, transform.position) >= 12)
        {
            _canControll = false;
            if (_justLeftRange == false)
            {
                _spawner.GetComponent<earthState>()._activeDisk = null;
                _justLeftRange = true;
            }
            if (_throwDisk == false)
            {
                _rb.useGravity = true;
            }
        }
    }

    void DestroyByTime()
    {
        if (_timer <= Time.time)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= -0.2f && _canControll == true)
        {
            _rb.MovePosition(transform.position + transform.up * Time.deltaTime * 12);
        }

        if (_throwDisk == true)
        {
            _rb.MovePosition(transform.position + transform.forward * Time.deltaTime * 60);
        }
    }
    public void OnThrow()
    {
        if (_canControll == true)
        {
            _rb.useGravity = true;
            _throwDisk = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("CRUMBLE");
        }
    }

    public void getSpawner(GameObject spawner)
    {
        _spawner = spawner;
    }
}
