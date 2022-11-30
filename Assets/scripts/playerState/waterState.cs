using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waterState : MonoBehaviour
{
    playerSetup _playerSetup;

    public GameObject _mainAbilityUI;
    public GameObject _secondaryAbilityUI;
    GameObject[] _UItoChange;
    GameObject _UIhealth;

    bool _waterShooting;
    bool _waterJetCoolingDown;

    GameObject _waterJet;
    GameObject _ActiveWaterJet;
    GameObject _iceCicle;

    float _curWaterJetTime;
    float _maxWaterJetTime = 2f;

    Transform _spawnTransform;

    [SerializeField] float Health;
    float maxHealth = 100;

    void Awake()
    {
        _playerSetup = gameObject.GetComponent<playerSetup>();
        enablingUI();
    }
    private void Start()
    {
        Health = 100;
        _spawnTransform = _playerSetup.SpawnPosition;
        _waterJet = _playerSetup.WaterJet;
        _iceCicle = _playerSetup.IceCicle;
        _waterShooting = false;
        _waterJetCoolingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        //primary Attack
        WaterJet();
        //secondary Attack
        IceCicles();

        UIUpdate();
    }

    void WaterJet()
    {
        
        if (Input.GetMouseButtonDown(0) && _waterJetCoolingDown == false)
        {
            bool justSpawned = false;
            if (_waterShooting == false)
            {
                _ActiveWaterJet = Instantiate(_waterJet, _spawnTransform.position, _spawnTransform.rotation, _spawnTransform);
                justSpawned = true;
                _waterShooting = true;
                _mainAbilityUI.GetComponent<Image>().fillAmount = 1;
            }
            if (justSpawned == false && _waterShooting == true)
            {
                _waterShooting = false;
                _ActiveWaterJet.transform.parent = null;
                _ActiveWaterJet.GetComponent<waterJet>().FREEZE();
                _curWaterJetTime = _maxWaterJetTime;
                _waterJetCoolingDown = true;
            }
        }
        if (_curWaterJetTime >= 0)
        {
            _curWaterJetTime -= Time.deltaTime;
        }
        if (_curWaterJetTime <= 0)
        {
            _waterJetCoolingDown = false;
        }
    }

    void IceCicles()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("ICE FIRE");
        }
    }

    void UIUpdate()
    {
        _UIhealth.GetComponent<Image>().fillAmount = Health / maxHealth;
        Health = Mathf.Clamp(Health, 0, maxHealth);

        if(_waterShooting == false)
            _mainAbilityUI.GetComponent<Image>().fillAmount = _curWaterJetTime / _maxWaterJetTime;
    }

    void enablingUI()
    {
        _mainAbilityUI = _playerSetup.UIMainAbility;
        _secondaryAbilityUI = _playerSetup.UISecondaryAbility;

        _UItoChange = _playerSetup.UItoChange;
        _playerSetup.UIWaterMA.SetActive(true);
        _playerSetup.UIWaterSA.SetActive(true);



        RectTransform topUIRect = _playerSetup.TopElementalUI[6].GetComponent<RectTransform>();
        topUIRect.localScale = new Vector3(0.075f, 0.15f, 1f);
        topUIRect.position = new Vector3(topUIRect.position.x, topUIRect.position.y, topUIRect.position.z);
        _playerSetup.TopElementalUI[7].GetComponent<Image>().fillAmount = 0;

        for (int i = 0; i < _UItoChange.Length; i++)
        {
            _UItoChange[i].GetComponent<Image>().color = Color.cyan;
        }

        _UIhealth = _playerSetup.UIHealth;

        _UIhealth.GetComponent<Image>().color = Color.cyan;
        _UIhealth.GetComponent<Image>().fillAmount = 1;

        _mainAbilityUI.GetComponent<Image>().fillAmount = 0;
        _secondaryAbilityUI.GetComponent<Image>().fillAmount = 0;
    }
}
