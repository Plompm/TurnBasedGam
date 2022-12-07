using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEarth : MonoBehaviour
{
    enemySetup _enemySetup;
    battleInfo _battleinfo;

    Transform _wallSpawnTransform;
    Transform _diskSpawnTransform;

    GameObject _earthWall;
    public GameObject _activeWall;

    GameObject _earthDisk;
    public GameObject _activeDisk;

    float _curWallRechargeTime;
    float _maxWallRechargeTime = 0.5f;

    float _curDiskRechargeTime;
    float _maxDiskRechargeTime = 0.25f;

    public float Health;
    float maxHealth = 100;

    float _wallRandomWaitTime;
    float _diskRandomWaitTime;

    bool _wallOnFirstAction;
    bool _diskOnFirstAction;
    bool _isGrounded;
    private void Awake()
    {
        _enemySetup = gameObject.GetComponent<enemySetup>();
        _battleinfo = gameObject.GetComponent<EnemyManager>().InfoManager.GetComponent<battleInfo>();
        _earthWall = _enemySetup.EarthWall;
        _earthDisk = _enemySetup.EarthDisk;
        _diskOnFirstAction = true;
        _wallOnFirstAction = true;
    }
    void Start()
    {
        Health = _battleinfo.EnemyEarthHealth;
        _wallSpawnTransform = _enemySetup.EarthWallSpawnPosition;
        _diskSpawnTransform = _enemySetup.EarthDiskSpawnPosition;
        _isGrounded = gameObject.GetComponent<EnemyAI>().isGrounded;
        setWallRandomWaitTime();
        setDiskRandomWaitTime();
    }
    // Update is called once per frame
    void Update()
    {
            //primary Attack
            EarthWall();
            //secondary Attack
            EarthDisk();
    }

    void EarthWall()
    {
        if (_wallRandomWaitTime <= Time.time)
        {
            bool justspawned = false;
            if (_activeWall == null)
            {
                _activeWall = Instantiate(_earthWall, _wallSpawnTransform.position, _wallSpawnTransform.rotation);
                _activeWall.GetComponent<earthWall>().getSpawner(gameObject);
                setWallRandomWaitTime();
                justspawned = true;
            }

            if (_activeWall != null && justspawned == false)
            {
                _activeWall.GetComponent<earthWall>().OnThrow();
                _activeWall = null;
                _curWallRechargeTime = _maxWallRechargeTime;
                setWallRandomWaitTime();
            }
        }
        if (_curWallRechargeTime > 0)
        {
            _curWallRechargeTime -= Time.deltaTime;
        }
    }

    void EarthDisk()
    {
        if (_diskRandomWaitTime <= Time.time)
        {
            bool justspawned = false;
            if (_activeDisk == null)
            {
                _activeDisk = Instantiate(_earthDisk, _diskSpawnTransform.position, _diskSpawnTransform.rotation);
                _activeDisk.GetComponent<earthDisk>().getSpawner(gameObject);
                justspawned = true;
                setDiskRandomWaitTime();
            }

            if (_activeDisk != null && justspawned == false)
            {
                _activeDisk.GetComponent<earthDisk>().OnThrow();
                _activeDisk = null;
                _curDiskRechargeTime = _maxDiskRechargeTime;
                setDiskRandomWaitTime();
            }
        }

        if (_curDiskRechargeTime > 0)
        {
            _curDiskRechargeTime -= Time.deltaTime;
        }
    }

    void setWallRandomWaitTime()
    {
        if (_wallOnFirstAction == true)
        {
            _wallRandomWaitTime = Time.time + Random.Range(0.5f, 0.7f);
            _wallOnFirstAction = false;
        }
        if (_wallOnFirstAction == false)
        {
            _wallRandomWaitTime = Time.time + Random.Range(1f, 7f);
            _wallOnFirstAction = true;
        }
    }
    void setDiskRandomWaitTime()
    {
        if (_diskOnFirstAction == true)
        {
            _diskRandomWaitTime = Time.time + Random.Range(0.4f, 3f);
            _diskOnFirstAction = false;
        }
        if (_diskOnFirstAction == false)
        {
            _diskRandomWaitTime = Time.time + Random.Range(0.3f, 1f);
            _diskOnFirstAction = true;
        }
    }
}
