using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceCicle : MonoBehaviour
{
    bool _hasBeenShot;
    Rigidbody _rb;
    float _timer;
    bool _timerStarted;
    GameObject _spawner;

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
        //Flame Thrower
        if (other.gameObject.layer == 7)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }
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
        //IceCicles
        if (other.gameObject.layer == 13)
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
        //ground
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
