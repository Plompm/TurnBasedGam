using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fireState : MonoBehaviour
{
    playerSetup _playerSetup;

    GameObject[] _UItoChange;
    GameObject _flameThrowerRef;
    GameObject _flameThrower;
    Transform _spawnTransform;
    ParticleSystem _particleSystemFlameThrower;

    GameObject _mainAbilityUI;
    GameObject _secondaryAbilityUI;

    float maxFlameThrowerCharge = 1;
    float curFlameThrowerCharge;
    bool _flameThrowerOn;

    private void Awake()
    {
        _playerSetup = gameObject.GetComponent<playerSetup>();
    }

    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        //primary Attack
        flamethrowerFunc();
        //secondary Attack
        if (Input.GetMouseButtonDown(1))
        {
           
        }

        UIUpdate();
    }

    void flamethrowerFunc()
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

    }

    void UIUpdate()
    {
        _mainAbilityUI.GetComponent<Image>().fillAmount = curFlameThrowerCharge / maxFlameThrowerCharge;

    }
}
