using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class earthWall : MonoBehaviour
{
    Rigidbody _rb;
    bool _throwWall;
    float _timer;
    bool _timerStarted;
    bool _canControll;
    bool _justLeftRange;
    GameObject _spawner;
    NavMeshObstacle _NavOb;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _throwWall = false;
        _canControll = true;
        _justLeftRange = false;
        _timerStarted = false;
        _NavOb = gameObject.GetComponent<NavMeshObstacle>();
        _NavOb.enabled = true;
    }

    private void Start()
    {

        _timer = Time.time + 5f;
    }

    private void Update()
    {
        DestroyByTime();
        if (_spawner.tag == "Player")
        {
            if (Vector3.Distance(Camera.main.transform.position, transform.position) >= 8 && _throwWall == false)
            {
                _rb.useGravity = true;
                _canControll = false;
                if (_justLeftRange == false)
                {
                    _justLeftRange = true;
                    _timerStarted = true;
                    _timer = Time.time + 2f;
                }
            }
        }
        if (_spawner.tag == "Enemy")
        {
            if (Vector3.Distance(_spawner.transform.position, transform.position) >= 12 && _throwWall == false)
            {
                _rb.useGravity = true;
                _canControll = false;
                if (_justLeftRange == false)
                {
                    _justLeftRange = true;
                    _timerStarted = true;
                    _timer = Time.time + 2f;
                }
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
        if (_spawner.tag == "Player")
        {
            transform.rotation = Camera.main.gameObject.transform.parent.rotation;
        }
        if (_spawner.tag == "Enemy")
        {
            transform.rotation = _spawner.transform.rotation;
        }
        _NavOb.enabled = false;
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
