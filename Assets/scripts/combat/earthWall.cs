using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class earthWall : MonoBehaviour
{
    Rigidbody _rb;
    bool _throwWall;
    float _timer;
    bool _timerStarted;
    bool _canControll;
    bool _justLeftRange;
    GameObject _spawner;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _throwWall = false;
        _canControll = true;
        _justLeftRange = false;
        _timerStarted = false;
    }

    private void Start()
    {

        _timer = Time.time + 5f;
    }

    private void Update()
    {
        DestroyByTime();
        if (Vector3.Distance(Camera.main.transform.position, transform.position) >= 8 && _throwWall == false)
        {
            _rb.useGravity = true;
            _canControll = false;
            if (_justLeftRange == false)
            {
                _spawner.GetComponent<earthState>()._activeWall = null;
                _justLeftRange = true;
                _timerStarted = true;
                _timer = Time.time + 2f;
            }
        }
    }

    void DestroyByTime()
    {
        if (_timer <= Time.time && _timerStarted)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (transform.position.y <= 0.8f && _canControll == true)
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
        _timerStarted = true;
        _timer = Time.time + 2f;
        transform.rotation = Camera.main.gameObject.transform.parent.rotation;
        print(Camera.main.gameObject.transform.parent.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("CRUNCH");
        }
    }

    public void getSpawner(GameObject spawner)
    {
        _spawner = spawner;
    }
}
