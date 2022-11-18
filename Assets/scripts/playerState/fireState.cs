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
    GameObject _UIhealth;

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

    [SerializeField] float Health;
    float maxHealth = 100;

    private void Awake()
    {
        _playerSetup = gameObject.GetComponent<playerSetup>();
    }

    void Start()
    {
        enablingUI();
        _curFireBallRechargeTime = 0;
        curFlameThrowerCharge = 0;

        Health = maxHealth;

        _spawnTransform = _playerSetup.SpawnPosition;
        
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
            if (Input.GetMouseButtonUp(0) && _flameThrowerOn == true)
            {
                _delayFlamerOn = true;
                _delayTimer = Time.time + 1;
                _flameThrowerOn = false;
                _flameThrower.GetComponent<CapsuleCollider>().enabled = false;
                _particleSystemFlameThrower.Stop(true);
            }

            if (_flameThrowerOn == false)
            {
                curFlameThrowerCharge -= Time.deltaTime;
                curFlameThrowerCharge = Mathf.Clamp(curFlameThrowerCharge, 0, maxFlameThrowerCharge);

            }
            if (_flameThrowerOn == true)
            {
                curFlameThrowerCharge += Time.deltaTime;
                curFlameThrowerCharge = Mathf.Clamp(curFlameThrowerCharge, 0, maxFlameThrowerCharge);
            }

            if (curFlameThrowerCharge >= maxFlameThrowerCharge)
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
            if (_curFireBallRechargeTime <= 0)
            {
                Instantiate(_FireBallRef, _spawnTransform.position, _spawnTransform.rotation);
                _curFireBallRechargeTime = _fireBallRechargeTime;
            }
        }

        if (_curFireBallRechargeTime > 0)
        {
            _curFireBallRechargeTime -= Time.deltaTime;
        }

    }

    void UIUpdate()
    {
        _mainAbilityUI.GetComponent<Image>().fillAmount = curFlameThrowerCharge / maxFlameThrowerCharge;
        _secondaryAbilityUI.GetComponent<Image>().fillAmount = _curFireBallRechargeTime / _fireBallRechargeTime;

        _UIhealth.GetComponent<Image>().fillAmount = Health / maxHealth;
        Health = Mathf.Clamp(Health, 0, maxHealth);
    }

    void enablingUI()
    {
        _mainAbilityUI = _playerSetup.UIMainAbility;
        _secondaryAbilityUI = _playerSetup.UISecondaryAbility;

        _UItoChange = _playerSetup.UItoChange;
        _playerSetup.UIFireMA.SetActive(true);
        _playerSetup.UIFireSA.SetActive(true);

        RectTransform topUIRect = _playerSetup.TopElementalUI[0].GetComponent<RectTransform>();
        topUIRect.localScale = new Vector3(0.075f, 0.15f,1f);
        topUIRect.position = new Vector3(topUIRect.position.x, topUIRect.position.y, topUIRect.position.z);
        _playerSetup.TopElementalUI[1].GetComponent<Image>().fillAmount = 0;

        for (int i = 0; i < _UItoChange.Length; i++)
        {
            _UItoChange[i].GetComponent<Image>().color = Color.red;
        }

        _UIhealth = _playerSetup.UIHealth;

        _UIhealth.GetComponent<Image>().color = Color.red;
        _UIhealth.GetComponent<Image>().fillAmount = 1;

    }
}
