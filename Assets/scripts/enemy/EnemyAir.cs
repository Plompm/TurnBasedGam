using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAir : MonoBehaviour
{

    enemySetup _enemySetup;

    Transform _spawnTransform;

    [SerializeField] float Health;
    float maxHealth = 100;

    GameObject _AirSliceRef;

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

    private void Awake()
    {
        _enemySetup = gameObject.GetComponent<enemySetup>();
        _AIMovement = gameObject.GetComponent<EnemyAI>();
        //adjust jump and speed here
    }
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        _spawnTransform = _enemySetup.SpawnPosition;
        _AirSliceRef = _enemySetup.AirSlice;
        _curAirSliceRechargeTime = 0;
        setRandomAirSliceTime();
        _canUseSecondaryAbility = true;
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
            Instantiate(_AirSliceRef, _spawnTransform.position, _spawnTransform.rotation);
            _curAirSliceRechargeTime = _AirSliceRechargeTime;
            setRandomAirSliceTime();
        }
    }

    void MoveBoostFunc()
    {
        //
        if (Input.GetMouseButtonDown(1))
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
        }
        if (_BoostcurrentTime < 0)
        {
            _curBoostRechargeTime = _maxBoostRechargeTime;
            _BoostcurrentTime = 0;
            //changeMovement
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
}
