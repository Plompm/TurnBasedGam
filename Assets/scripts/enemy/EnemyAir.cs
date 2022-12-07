using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAir : MonoBehaviour
{

    enemySetup _enemySetup;
    battleInfo _battleinfo;

    Transform _spawnTransform;

    public float Health;
    float maxHealth = 100;

    GameObject _AirSliceRef;
    GameObject _activeAirSlice;

    float _curAirSliceRechargeTime;
    float _AirSliceRechargeTime = 0.25f;

    float _maxBoostRechargeTime = 7f;
    float _curBoostRechargeTime;
    float _BoostTimeLimit = 5f;
    float _BoostcurrentTime;
    bool _canUseSecondaryAbility;

    EnemyAI _AIMovement;
    float _startSpeed;
    float _startJump;

    float _airSliceRandomWaitTime;
    float _windBoastRandomWaitTime;

    private void Awake()
    {
        _enemySetup = gameObject.GetComponent<enemySetup>();
        _battleinfo = gameObject.GetComponent<EnemyManager>().InfoManager.GetComponent<battleInfo>();
        _AIMovement = gameObject.GetComponent<EnemyAI>();
        //adjust jump and speed here
        _startSpeed = _AIMovement.AINavMeshAgent.speed;
        _startJump = _AIMovement.JumpHeight;
    }
    // Start is called before the first frame update
    void Start()
    {
        Health = _battleinfo.EnemyAirHealth;
        _spawnTransform = _enemySetup.SpawnPosition;
        _AirSliceRef = _enemySetup.AirSlice;
        _curAirSliceRechargeTime = 0;
        setRandomAirSliceTime();
        _canUseSecondaryAbility = true;
        _startJump = _AIMovement.JumpHeight;
    }

    // Update is called once per frame
    void Update()
    {
        //primary Attack
        WindSliceFunc();
        //secondary Attack
        MoveBoostFunc();
    }

    void WindSliceFunc()
    {
        if (_airSliceRandomWaitTime <= Time.time)
        {
            _activeAirSlice = Instantiate(_AirSliceRef, _spawnTransform.position, _spawnTransform.rotation);
            _activeAirSlice.GetComponent<AirSlice>().getSpawner(gameObject);
            _curAirSliceRechargeTime = _AirSliceRechargeTime;
            setRandomAirSliceTime();
        }
    }

    void MoveBoostFunc()
    {
        //
        if (_windBoastRandomWaitTime <= Time.time)
        {
            if (_canUseSecondaryAbility == true && _curBoostRechargeTime <= 0)
            {
                _canUseSecondaryAbility = false;
                _BoostcurrentTime = _BoostTimeLimit;
            }
        }

        if (_BoostcurrentTime > 0)
        {
            _BoostcurrentTime -= Time.deltaTime;
            //changeMovement
            _AIMovement.AINavMeshAgent.speed = 20;
            _AIMovement.JumpHeight = 12;
        }
        if (_BoostcurrentTime < 0)
        {
            _curBoostRechargeTime = _maxBoostRechargeTime;
            _BoostcurrentTime = 0;
            //changeMovement
            _AIMovement.AINavMeshAgent.speed = _startSpeed;
            _AIMovement.JumpHeight = _startJump;
        }

        if (_curBoostRechargeTime > 0)
        {
            _curBoostRechargeTime -= Time.deltaTime;
        }
        if (_curBoostRechargeTime < 0)
        {
            _canUseSecondaryAbility = true;
            _curBoostRechargeTime = 0;
        }
    }

    void setRandomAirSliceTime()
    {
        _airSliceRandomWaitTime = Time.time + Random.Range(0.5f, 2);
    }
    void setRandomWindBoostTime()
    { 
        _windBoastRandomWaitTime = Time.time + Random.Range(7f, 15f);
    }
}
