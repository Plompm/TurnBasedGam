using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class earthWall : MonoBehaviour
{
    float _damage = 40;
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

        //earthWall
        if (other.gameObject.layer == 10)
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
                findEnemyType(other.gameObject);
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
            //vfx
            //audio
            Destroy(gameObject);
        }
        //only hurt enemy
        if (_spawner.tag == "Player")
        {
            if (other.gameObject.tag == "Enemy")
            {
                //vfx
                //audio
                findEnemyType(other.gameObject);
                Destroy(gameObject);
            }
        }

        //only hurt player
        if (_spawner.tag == "Enemy")
        {
            if (other.gameObject.tag == "Player")
            {
                //vfx
                //audio
                findPlayerType(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
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
