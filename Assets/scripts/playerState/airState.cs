using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class airState : MonoBehaviour
{
    playerSetup _playerSetup;

    GameObject _mainAbilityUI;
    GameObject _secondaryAbilityUI;
    GameObject[] _UItoChange;
    GameObject _UIhealth;
    GameObject _UIAbilityInUse;

    Transform _spawnTransform;

    [SerializeField] float Health;
    float maxHealth = 100;

    GameObject _AirSliceRef;

    float _curAirSliceRechargeTime;
    float _AirSliceRechargeTime = 0.25f;

    float _maxBoostRechargeTime = 4f;
    float _curBoostRechargeTime;
    float _BoostTimeLimit = 2f;
    float _BoostcurrentTime;
    bool _canUseSecondaryAbility;
    private void Awake()
    {
        _playerSetup = gameObject.GetComponent<playerSetup>();
    }

    void Start()
    {
        enablingUI();
        Health = maxHealth;
        _spawnTransform = _playerSetup.SpawnPosition;
        _AirSliceRef = _playerSetup.AirSlice;
        _curAirSliceRechargeTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //primary Attack
        WindSliceFunc();
        //secondary Attack
        MoveBoostFunc();

        UIUpdate();
    }


    void WindSliceFunc()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_curAirSliceRechargeTime <= 0)
            {
                Instantiate(_AirSliceRef, _spawnTransform.position, _spawnTransform.rotation);
                _curAirSliceRechargeTime = _AirSliceRechargeTime;
            }
        }

        if (_curAirSliceRechargeTime > 0)
        {
            _curAirSliceRechargeTime -= Time.deltaTime;
        }
    }

    void MoveBoostFunc()
    {
        //
        if (Input.GetMouseButtonDown(1))
        {
            if (_canUseSecondaryAbility == true)
            {
                _canUseSecondaryAbility = false;
                _BoostcurrentTime = _BoostTimeLimit;
            }
        }

        if (_BoostcurrentTime > 0)
        {
            _BoostcurrentTime -= Time.deltaTime;
        }

        if (_BoostTimeLimit <= 0)
        {
            _curBoostRechargeTime -= Time.deltaTime;
        }
    }

    void UIUpdate()
    {
        _UIAbilityInUse.GetComponent<Image>().fillAmount = _BoostcurrentTime / _BoostTimeLimit;
        _secondaryAbilityUI.GetComponent<Image>().fillAmount = _curBoostRechargeTime / _maxBoostRechargeTime;
        _mainAbilityUI.GetComponent<Image>().fillAmount = _curAirSliceRechargeTime / _AirSliceRechargeTime;

        _UIhealth.GetComponent<Image>().fillAmount = Health / maxHealth;
        Health = Mathf.Clamp(Health, 0, maxHealth);
    }

    void enablingUI()
    {
        _mainAbilityUI = _playerSetup.UIMainAbility;
        _secondaryAbilityUI = _playerSetup.UISecondaryAbility;

        _UItoChange = _playerSetup.UItoChange;
        _playerSetup.UIAirMA.SetActive(true);
        _playerSetup.UIAirSA.SetActive(true);



        RectTransform topUIRect = _playerSetup.TopElementalUI[2].GetComponent<RectTransform>();
        topUIRect.localScale = new Vector3(0.075f, 0.15f, 1f);
        topUIRect.position = new Vector3(topUIRect.position.x, topUIRect.position.y, topUIRect.position.z);
        _playerSetup.TopElementalUI[3].GetComponent<Image>().fillAmount = 0;

        for (int i = 0; i < _UItoChange.Length; i++)
        {
            _UItoChange[i].GetComponent<Image>().color = Color.white;
        }

        _UIhealth = _playerSetup.UIHealth;

        _UIhealth.GetComponent<Image>().color = Color.white;
        _UIhealth.GetComponent<Image>().fillAmount = 1;
        _UIAbilityInUse = _playerSetup.UISecondAbilityinUse;
        _UIAbilityInUse.GetComponent<Image>().fillAmount = 0;
        _secondaryAbilityUI.GetComponent<Image>().fillAmount = 0;
    }
}
