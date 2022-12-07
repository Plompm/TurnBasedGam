using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWater : MonoBehaviour
{
    enemySetup _enemySetup;

    bool _waterShooting;
    bool _waterJetCoolingDown;

    GameObject _waterJet;
    GameObject _ActiveWaterJet;
    GameObject _iceCicle;
    GameObject[] _ActiveIceCicles;
    bool[] _iceCicleSpawned;
    Transform[] _iceCicleSpawnPos;
    GameObject _player;

    float _IceCicleCharge;

    float _curWaterJetTime;
    float _maxWaterJetTime = 2f;
    bool _justSpawned;

    Transform _spawnTransform;

    [SerializeField] float Health;
    float maxHealth = 100;

    float _waterJetRandomWaitTime;
    float _IceCicleRandomWaitTime;

    bool _waterJetOnFirstAction;
    bool _IceCicleOnFirstAction;

    void Awake()
    {
        _enemySetup = gameObject.GetComponent<enemySetup>();
    }
    private void Start()
    {
        Health = 100;
        _spawnTransform = _enemySetup.SpawnPosition;
        _waterJet = _enemySetup.WaterJet;
        _iceCicle = _enemySetup.IceCicle;
        _waterShooting = false;
        _waterJetCoolingDown = false;
        _iceCicleSpawned = new bool[3];
        for (int i = 0; i < 2; i++)
        {
            _iceCicleSpawned[i] = false;
        }
        _ActiveIceCicles = new GameObject[3];
        _iceCicleSpawnPos = _enemySetup.IceCicleSpawnPos;
        _player = gameObject.GetComponent<EnemyAI>().Player;
        _IceCicleOnFirstAction = false;
        setwaterJetRandomWaitTime();
        setIceCicleRandomWaitTime();
    }

    // Update is called once per frame
    void Update()
    {
        //primary Attack
        WaterJet();
        //secondary Attack
        IceCicles();
    }

    void WaterJet()
    {

        if (Vector3.Distance(_player.transform.position, transform.position) <= 20 && _waterJetRandomWaitTime <= Time.time)
        {
            bool justSpawned = false;
            if (_waterShooting == false && _curWaterJetTime <= 0)
            {
                _ActiveWaterJet = Instantiate(_waterJet, _spawnTransform.position, _spawnTransform.rotation, _spawnTransform);
                justSpawned = true;
                _waterShooting = true;
                _curWaterJetTime = _maxWaterJetTime;
                setwaterJetRandomWaitTime();
                _ActiveWaterJet.GetComponent<waterJet>().getSpawner(gameObject);
            }
            if (justSpawned == false && _waterShooting == true)
            {
                _waterShooting = false;
                _ActiveWaterJet.transform.parent = null;
                _ActiveWaterJet.GetComponent<waterJet>().FREEZE();
                _ActiveWaterJet = null;
                _curWaterJetTime = _maxWaterJetTime;
                _waterJetCoolingDown = true;
                setwaterJetRandomWaitTime();
            }
            _justSpawned = justSpawned;
        }
        if (_justSpawned == true)
        {
            _curWaterJetTime -= Time.deltaTime;
        }
        if (_curWaterJetTime >= 0 && _justSpawned == false)
        {
            _curWaterJetTime -= Time.deltaTime;
        }
        if (_curWaterJetTime <= 0)
        {
            _waterJetCoolingDown = false;
            if (_ActiveWaterJet != null)
            {
                _ActiveWaterJet.GetComponent<waterJet>().FREEZE();
                _ActiveWaterJet = null;
                _waterShooting = false;
                _curWaterJetTime = _maxWaterJetTime;
                setwaterJetRandomWaitTime();
            }
        }
    }

    void IceCicles()
    {
        if (_IceCicleOnFirstAction == true)
        {
            _IceCicleCharge += Time.deltaTime;
        }
        if (_IceCicleCharge >= 0.3f && _iceCicleSpawned[0] == false)
        {
            _iceCicleSpawned[0] = true;
            _ActiveIceCicles[0] = Instantiate(_iceCicle, _iceCicleSpawnPos[0].position, _iceCicleSpawnPos[0].rotation);
            _ActiveIceCicles[0].GetComponent<iceCicle>().OnSpawn(_iceCicleSpawnPos[0]);
            _ActiveIceCicles[0].GetComponent<iceCicle>().getSpawner(gameObject);
        }
        if (_IceCicleCharge >= 0.8f && _iceCicleSpawned[1] == false)
        {
            _iceCicleSpawned[1] = true;
            _ActiveIceCicles[1] = Instantiate(_iceCicle, _iceCicleSpawnPos[1].position, _iceCicleSpawnPos[1].rotation);
            _ActiveIceCicles[1].transform.localScale = new Vector3(_ActiveIceCicles[1].transform.localScale.x * -1, _ActiveIceCicles[1].transform.localScale.y, _ActiveIceCicles[1].transform.localScale.z);
            _ActiveIceCicles[1].GetComponent<iceCicle>().OnSpawn(_iceCicleSpawnPos[1]);
            _ActiveIceCicles[1].GetComponent<iceCicle>().getSpawner(gameObject);
        }
        if (_IceCicleCharge >= 1.5f && _iceCicleSpawned[2] == false)
        {
            _iceCicleSpawned[2] = true;
            _ActiveIceCicles[2] = Instantiate(_iceCicle, _iceCicleSpawnPos[2].position, _iceCicleSpawnPos[2].rotation);
            _ActiveIceCicles[2].GetComponent<iceCicle>().OnSpawn(_iceCicleSpawnPos[2]);
            _ActiveIceCicles[2].GetComponent<iceCicle>().getSpawner(gameObject);
            _IceCicleOnFirstAction = false;
            _IceCicleRandomWaitTime += 10;
        }

        if (_IceCicleOnFirstAction == false)
        {
            _IceCicleCharge = 0;
            for (int i = 0; i < _iceCicleSpawned.Length; i++)
            {
                if (_iceCicleSpawned[i] == true)
                {
                    if (_ActiveIceCicles[i] != null)
                    {
                        _ActiveIceCicles[i].GetComponent<iceCicle>().OnShot();
                    }
                    setIceCicleRandomWaitTime();
                }
                _iceCicleSpawned[i] = false;
            }
        }
        if (_IceCicleRandomWaitTime <= Time.time)
        {
            _IceCicleOnFirstAction = true;
        }
    }

    void setwaterJetRandomWaitTime()
    {
        if (_waterJetOnFirstAction == true)
        {
            _waterJetRandomWaitTime = Time.time + Random.Range(2f, 5f);
            _waterJetOnFirstAction = false;
        }
        if (_waterJetOnFirstAction == false)
        {
            _waterJetRandomWaitTime = Time.time + 2.5f;
            _waterJetOnFirstAction = true;
        }
    }
    void setIceCicleRandomWaitTime()
    {
        _IceCicleRandomWaitTime = Time.time + Random.Range(1f, 5f);
    }
}
