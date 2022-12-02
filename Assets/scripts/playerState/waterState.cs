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
    GameObject[] _ActiveIceCicles;
    bool[] _iceCicleSpawned;
    Transform[] _iceCicleSpawnPos;

    float _IceCicleCharge;

    float _curWaterJetTime;
    float _maxWaterJetTime = 2f;
    bool _justSpawned;

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
        _iceCicleSpawned = new bool[3];
        for (int i = 0; i < 2; i++)
        {
            _iceCicleSpawned[i] = false;
        }
        _ActiveIceCicles = new GameObject[3];
        _iceCicleSpawnPos = _playerSetup.IceCicleSpawnPos;
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
            if (_waterShooting == false && _curWaterJetTime <= 0)
            {
                _ActiveWaterJet = Instantiate(_waterJet, _spawnTransform.position, _spawnTransform.rotation, _spawnTransform);
                justSpawned = true;
                _waterShooting = true;
                _curWaterJetTime = _maxWaterJetTime;
            }
            if (justSpawned == false && _waterShooting == true)
            {
                _waterShooting = false;
                _ActiveWaterJet.transform.parent = null;
                _ActiveWaterJet.GetComponent<waterJet>().FREEZE();
                _ActiveWaterJet = null;
                _curWaterJetTime = _maxWaterJetTime;
                _waterJetCoolingDown = true;
                _iceCicle = _playerSetup.IceCicle;
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
            }
        }
    }

    void IceCicles()
    {
        if (Input.GetMouseButton(1))
        {
            _IceCicleCharge += Time.deltaTime;
        }
        if (_IceCicleCharge >= 0.3f && _iceCicleSpawned[0] == false)
        {
            _iceCicleSpawned[0] = true;
            _ActiveIceCicles[0] = Instantiate(_iceCicle, _iceCicleSpawnPos[0].position, _iceCicleSpawnPos[0].rotation);
            _ActiveIceCicles[0].GetComponent<iceCicle>().OnSpawn(_iceCicleSpawnPos[0]);
        }
        if (_IceCicleCharge >= 0.8f && _iceCicleSpawned[1] == false)
        {
            _iceCicleSpawned[1] = true;
            _ActiveIceCicles[1] = Instantiate(_iceCicle, _iceCicleSpawnPos[1].position, _iceCicleSpawnPos[1].rotation);
            _ActiveIceCicles[1].transform.localScale = new Vector3(_ActiveIceCicles[1].transform.localScale.x * -1, _ActiveIceCicles[1].transform.localScale.y, _ActiveIceCicles[1].transform.localScale.z);
            _ActiveIceCicles[1].GetComponent<iceCicle>().OnSpawn(_iceCicleSpawnPos[1]);
        }
        if (_IceCicleCharge >= 1.5f && _iceCicleSpawned[2] == false)
        {
            _iceCicleSpawned[2] = true;
            _ActiveIceCicles[2] = Instantiate(_iceCicle, _iceCicleSpawnPos[2].position, _iceCicleSpawnPos[2].rotation);
            _ActiveIceCicles[2].GetComponent<iceCicle>().OnSpawn(_iceCicleSpawnPos[2]);
        }

        if (Input.GetMouseButtonUp(1))
        {
            _IceCicleCharge = 0;
            for (int i = 0; i < _iceCicleSpawned.Length; i++)
            {
                if (_iceCicleSpawned[i] == true)
                {
                    _ActiveIceCicles[i].GetComponent<iceCicle>().OnShot();
                }
                _iceCicleSpawned[i] = false;
            }
        }
    }

    void UIUpdate()
    {
        _UIhealth.GetComponent<Image>().fillAmount = Health / maxHealth;
        Health = Mathf.Clamp(Health, 0, maxHealth);

        _mainAbilityUI.GetComponent<Image>().fillAmount = _curWaterJetTime / _maxWaterJetTime;

        _secondaryAbilityUI.GetComponent<Image>().fillAmount = _IceCicleCharge / 1.5f;
        _IceCicleCharge = Mathf.Clamp(_IceCicleCharge, 0, 1.5f);
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
