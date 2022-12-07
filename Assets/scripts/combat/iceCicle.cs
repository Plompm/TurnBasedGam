using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class iceCicle : MonoBehaviour
{
    float _damage = 15;
    bool _hasBeenShot;
    Rigidbody _rb;
    float _timer;
    bool _timerStarted;
    GameObject _spawner;
    [SerializeField] GameObject _iceShatter;
    [SerializeField] SFXEvent _summon;
    [SerializeField] SFXEvent _break;
    [SerializeField] SFXEvent _send;

    private void Awake()
    {
        _hasBeenShot = false;
        _rb = gameObject.GetComponent<Rigidbody>();
        _timerStarted = false;
        _summon.Play();
    }

    public void OnSpawn(Transform parent)
    {
        transform.parent = parent;
    }
    public void OnShot()
    {
        _send.Play();
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
            Utility.SpawnParticles(_iceShatter, gameObject, false);
            _break.Play();
            Destroy(gameObject);
        }
        //FireBall
        if (other.gameObject.layer == 8)
        {
            Utility.SpawnParticles(_iceShatter, gameObject, false);
            _break.Play();
            Destroy(gameObject);
        }

        //earthWall
        if (other.gameObject.layer == 10)
        {
            Utility.SpawnParticles(_iceShatter, gameObject, false);
            _break.Play();
            Destroy(gameObject);
        }
        //earthDisk
        if (other.gameObject.layer == 11)
        {
            Utility.SpawnParticles(_iceShatter, gameObject, false);
            _break.Play();
            Destroy(gameObject);
        }
        //IceCicles
        if (other.gameObject.layer == 13)
        {
            Utility.SpawnParticles(_iceShatter, gameObject, false);
            _break.Play();
            Destroy(gameObject);
        }

        //only hurt enemy
        if (_spawner.tag == "Player")
        {
            if (other.tag == "Enemy")
            {
                Utility.SpawnParticles(_iceShatter, gameObject, false);
                _break.Play();
                findEnemyType(other.gameObject);
                Destroy(gameObject);
            }
        }

        //only hurt player
        if (_spawner.tag == "Enemy")
        {
            if (other.tag == "Player")
            {
                Utility.SpawnParticles(_iceShatter, gameObject, false);
                _break.Play();
                findPlayerType(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //walls
        if (other.gameObject.layer == 10)
        {
            Utility.SpawnParticles(_iceShatter, gameObject, false);
            _break.Play();
            Destroy(gameObject);
        }
        //ground
        if (other.gameObject.layer == 6)
        {
            Utility.SpawnParticles(_iceShatter, gameObject, false);
            _break.Play();
            Destroy(gameObject);
        }
    }

    public void getSpawner(GameObject spawner)
    {
        _spawner = spawner;
    }

    void findEnemyType(GameObject other)
    {
        if (other.gameObject.GetComponent<EnemyManager>().GivenState == enemyAction.FireAttack)
        {
            other.GetComponent<EnemyFire>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<EnemyManager>().GivenState == enemyAction.AirAttack)
        {
            other.GetComponent<EnemyAir>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<EnemyManager>().GivenState == enemyAction.EarthAttack)
        {
            other.GetComponent<EnemyEarth>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<EnemyManager>().GivenState == enemyAction.WaterAttack)
        {
            other.GetComponent<EnemyWater>().Health -= _damage;
        }
    }

    void findPlayerType(GameObject other)
    {
        if (other.gameObject.GetComponent<PlayerManager>().GivenState == playerAction.FireAttack)
        {
            other.GetComponent<fireState>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<PlayerManager>().GivenState == playerAction.AirAttack)
        {
            other.GetComponent<airState>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<PlayerManager>().GivenState == playerAction.EarthAttack)
        {
            other.GetComponent<earthState>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<PlayerManager>().GivenState == playerAction.WaterAttack)
        {
            other.GetComponent<waterState>().Health -= _damage;
        }
    }
}
