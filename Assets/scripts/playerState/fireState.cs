using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireState : MonoBehaviour
{
    playerSetup _playerSetup;

    GameObject _mainAbilityUI;
    GameObject _secondaryAbilityUI;
    GameObject[] _UItoChange;

    GameObject _flameThrowerRef;
    GameObject _flameThrower;
    Transform _spawnTransform;
    ParticleSystem _particleSystemFlameThrower;

    float maxFlameThrowerCharge = 1;
    float curFlameThrowerCharge;
    float _delayTimer;
    bool _delayFlamerOn;
    bool _flameThrowerOn;

    GameObject _FireBallRef;
    
    float _curFireBallRechargeTime;
    float _fireBallRechargeTime = 2;

    private void Awake()
    {
        _playerSetup = gameObject.GetComponent<playerSetup>();
    }

    void Start()
    {
        _curFireBallRechargeTime = _fireBallRechargeTime;
        curFlameThrowerCharge = maxFlameThrowerCharge;
        _mainAbilityUI = _playerSetup.UIMainAbility;
        _secondaryAbilityUI = _playerSetup.UISecondaryAbility;

        _UItoChange = _playerSetup.UItoChange;
        _spawnTransform = _playerSetup.SpawnPosition;

        for (int i = 0; i < _UItoChange.Length; i++)
        {
            _UItoChange[i].GetComponent<Image>().color = Color.red;
        }
        
        _flameThrowerRef = _playerSetup.FlameThrower;
        _FireBallRef = _playerSetup.FireBall;
    }

    // Update is called once per frame
    void Update()
    {
        //primary Attack
        flamethrowerFunc();
        //secondary Attack
        fireBallFunc();

        UIUpdate();
    }

    void flamethrowerFunc()
    {
        if (_delayFlamerOn == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (_flameThrower == null)
                {
                    _flameThrower = Instantiate(_flameThrowerRef, _spawnTransform.position, _spawnTransform.rotation, _spawnTransform);
                    _particleSystemFlameThrower = _flameThrower.GetComponent<ParticleSystem>();
                }

                _flameThrower.GetComponent<CapsuleCollider>().enabled = true;
                _particleSystemFlameThrower.Play();
                _flameThrowerOn = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                _delayFlamerOn = true;
                _delayTimer = Time.time + 1;
                _flameThrowerOn = false;
                _flameThrower.GetComponent<CapsuleCollider>().enabled = false;
                _particleSystemFlameThrower.Stop(true);
            }

            if (_flameThrowerOn == false)
            {
                curFlameThrowerCharge += Time.deltaTime;
                curFlameThrowerCharge = Mathf.Clamp(curFlameThrowerCharge, 0, maxFlameThrowerCharge);

            }
            if (_flameThrowerOn == true)
            {
                curFlameThrowerCharge -= Time.deltaTime;
                curFlameThrowerCharge = Mathf.Clamp(curFlameThrowerCharge, 0, maxFlameThrowerCharge);
            }

            if (curFlameThrowerCharge <= 0)
            {
                _delayFlamerOn = true;
                _delayTimer = Time.time + 1;
                _flameThrowerOn = false;
                _flameThrower.GetComponent<CapsuleCollider>().enabled = false;
                _particleSystemFlameThrower.Stop(true);
            }
        }

        if (_delayFlamerOn == true && _delayTimer <= Time.time)
        {
            _delayFlamerOn = false;
        }

    }

    void fireBallFunc()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (_curFireBallRechargeTime >= _fireBallRechargeTime)
            {
                Instantiate(_FireBallRef, _spawnTransform.position, _spawnTransform.rotation);
                _curFireBallRechargeTime = 0;
            }
        }

        if (_curFireBallRechargeTime < _fireBallRechargeTime)
        {
            _curFireBallRechargeTime += Time.deltaTime;
        }

    }

    void UIUpdate()
    {
        _mainAbilityUI.GetComponent<Image>().fillAmount = curFlameThrowerCharge / maxFlameThrowerCharge;
        _secondaryAbilityUI.GetComponent<Image>().fillAmount = _curFireBallRechargeTime / _fireBallRechargeTime;
    }
}
