using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class earthDisk : MonoBehaviour
{
    Rigidbody _rb;
    bool _throwDisk;
    float _timer;
    bool _timerStarted;
    bool _canControll;
    GameObject _spawner;
    bool _justLeftRange;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _throwDisk = false;
        _canControll = true;
        _justLeftRange = false;
        _timerStarted = false;
    }

    private void Update()
    {
        DestroyByTime();
        if (_spawner.tag == "Player")
        {
            if (_canControll == true)
            {
                transform.rotation = Camera.main.transform.rotation;
            }
            if (Vector3.Distance(Camera.main.transform.position, transform.position) >= 12)
            {
                _timerStarted = true;
                _canControll = false;
                if (_justLeftRange == false)
                {
                    _justLeftRange = true;
                    _timer = Time.time + 3f;
                }
                if (_throwDisk == false)
                {
                    _rb.useGravity = true;
                }
            }
        }
        if (_spawner.tag == "Enemy")
        {
            if (_canControll == true)
            {
                transform.rotation = _spawner.GetComponent<enemySetup>().AimAngle.rotation;
            }
            if (Vector3.Distance(transform.position, transform.position) >= 15)
            {
                _timerStarted = true;
                _canControll = false;
                if (_justLeftRange == false)
                {
                    _justLeftRange = true;
                    _timer = Time.time + 3f;
                }
                if (_throwDisk == false)
                {
                    _rb.useGravity = true;
                }
            }
        }
    }

    void DestroyByTime()
    {
        if (_timer <= Time.time && _timerStarted == true)
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
            if (_spawner.tag == "Enemy")
            {
                transform.LookAt(_spawner.GetComponent<EnemyAI>().Player.transform);
            }
        }
        _timerStarted = true;
        _timer = Time.time + 5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        //FireBall
        if (other.gameObject.layer == 8)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }

        //earthWall
        if (other.gameObject.layer == 10)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }
        //earthDisk
        if (other.gameObject.layer == 11)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }
        //only hurt enemy
        if (_spawner.tag == "Player")
        {
            if (other.tag == "Enemy")
            {
                //vfx
                //audio
                Destroy(gameObject);
            }
        }

        //only hurt player
        if (_spawner.tag == "Enemy")
        {
            if (other.tag == "Player")
            {
                //vfx
                //audio
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //walls
        if (other.gameObject.layer == 10)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }
    }

    public void getSpawner(GameObject spawner)
    {
        _spawner = spawner;
    }
}
