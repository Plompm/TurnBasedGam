using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class earthState : MonoBehaviour
{
    playerSetup _playerSetup;

    public GameObject _mainAbilityUI;
    public GameObject _secondaryAbilityUI;
    Image _mainCoolDownFill;
    Image _secondaryCoolDownFill;
    GameObject[] _UItoChange;
    GameObject _UIhealth;

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

    [SerializeField] float Health;
    float maxHealth = 100;

    private void Awake()
    {
        _playerSetup = gameObject.GetComponent<playerSetup>();
        enablingUI();

        _earthWall = _playerSetup.EarthWall;
        _earthDisk = _playerSetup.EarthDisk;
    }
    void Start()
    {
        Health = maxHealth;
        _wallSpawnTransform = _playerSetup.EarthWallSpawnPosition;
        _diskSpawnTransform = _playerSetup.EarthDiskSpawnPosition;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<playerMovement>().isGrounded == true)
        {
            //primary Attack
            EarthWall();
            //secondary Attack
            EarthDisk();
        }


        UIUpdate();
    }

    void EarthWall()
    {
        if (Input.GetMouseButtonDown(0) && _curWallRechargeTime <= 0)
        {
            bool justspawned = false;
            if (_activeWall == null)
            {
                _activeWall = Instantiate(_earthWall, _wallSpawnTransform.position, _wallSpawnTransform.rotation);
                _activeWall.GetComponent<earthWall>().getSpawner(gameObject);
                justspawned = true;
            }

            if (_activeWall != null && justspawned == false)
            {
                _activeWall.GetComponent<earthWall>().OnThrow();
                _activeWall = null;
                _curWallRechargeTime = _maxWallRechargeTime;
            }
        }
        if (_curWallRechargeTime > 0)
        {
            _curWallRechargeTime -= Time.deltaTime;
        }
    }

    void EarthDisk()
    {
        if (Input.GetMouseButtonDown(1) && _curDiskRechargeTime <= 0)
        {
            bool justspawned = false;
            if (_activeDisk == null)
            {
                _activeDisk = Instantiate(_earthDisk, _diskSpawnTransform.position, _diskSpawnTransform.rotation);
                _activeDisk.GetComponent<earthDisk>().getSpawner(gameObject);
                justspawned = true;
            }

            if (_activeDisk != null && justspawned == false)
            {
                _activeDisk.GetComponent<earthDisk>().OnThrow();
                _activeDisk = null;
                _curDiskRechargeTime = _maxDiskRechargeTime;
            }
        }

        if (_curDiskRechargeTime > 0)
        {
            _curDiskRechargeTime -= Time.deltaTime;
        }
    }


    void UIUpdate()
    {
        _UIhealth.GetComponent<Image>().fillAmount = Health / maxHealth;
        Health = Mathf.Clamp(Health, 0, maxHealth);

        _mainCoolDownFill.fillAmount = _curWallRechargeTime / _maxWallRechargeTime;
        _secondaryCoolDownFill.fillAmount = _curDiskRechargeTime / _maxDiskRechargeTime;

        if (_activeWall == null)
        {
            _mainAbilityUI.GetComponent<Image>().fillAmount = 0f;
        }
        else
        {
            _mainAbilityUI.GetComponent<Image>().fillAmount = 1f;
        }
        if (_activeDisk == null)
        {
            _secondaryAbilityUI.GetComponent<Image>().fillAmount = 0f;
        }
        else
        {
            _secondaryAbilityUI.GetComponent<Image>().fillAmount = 1f;
        }
    }

    void enablingUI()
    {
        _mainAbilityUI = _playerSetup.UIMainAbility;
        _secondaryAbilityUI = _playerSetup.UISecondaryAbility;

        _playerSetup.UIMainAbilityInUse.SetActive(true);
        _playerSetup.UISecondAbilityinUse.SetActive(true);

        _mainCoolDownFill = _playerSetup.UIMainAbilityInUse.GetComponent<Image>();
        _secondaryCoolDownFill = _playerSetup.UISecondAbilityinUse.GetComponent<Image>();

        _UItoChange = _playerSetup.UItoChange;
        _playerSetup.UIEarthMA.SetActive(true);
        _playerSetup.UIEarthSA.SetActive(true);



        RectTransform topUIRect = _playerSetup.TopElementalUI[4].GetComponent<RectTransform>();
        topUIRect.localScale = new Vector3(0.075f, 0.15f, 1f);
        topUIRect.position = new Vector3(topUIRect.position.x, topUIRect.position.y, topUIRect.position.z);
        _playerSetup.TopElementalUI[5].GetComponent<Image>().fillAmount = 0;

        for (int i = 0; i < _UItoChange.Length; i++)
        {
            _UItoChange[i].GetComponent<Image>().color = Color.green;
        }

        _UIhealth = _playerSetup.UIHealth;

        _UIhealth.GetComponent<Image>().color = Color.green;
        _UIhealth.GetComponent<Image>().fillAmount = 1;

        _mainAbilityUI.GetComponent<Image>().fillAmount = 0;
        _secondaryAbilityUI.GetComponent<Image>().fillAmount = 0;
        _mainAbilityUI.GetComponent<Image>().color = Color.red;
        _secondaryAbilityUI.GetComponent<Image>().color = Color.red;

        _mainCoolDownFill.color = new Color(0,0,0,0.5f);
        _secondaryCoolDownFill.color = new Color(0, 0, 0, 0.5f);

        _mainCoolDownFill.fillAmount = 0;
        _secondaryCoolDownFill.fillAmount = 0;
    }
}
