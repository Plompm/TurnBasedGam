using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class earthState : MonoBehaviour
{
    playerSetup _playerSetup;

    GameObject _mainAbilityUI;
    GameObject _secondaryAbilityUI;
    GameObject[] _UItoChange;
    GameObject _UIhealth;
    GameObject _UIAbilityInUse;

    Transform _spawnTransform;

    GameObject _earthWall;
    GameObject _earthDisk;

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
        _spawnTransform = _playerSetup.EarthSpawnPosition;
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
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_earthWall, _spawnTransform.position, _spawnTransform.rotation);
        }
    }

    void EarthDisk()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("earth Disk");
        }
    }


    void UIUpdate()
    {
        _UIhealth.GetComponent<Image>().fillAmount = Health / maxHealth;
        Health = Mathf.Clamp(Health, 0, maxHealth);
    }

    void enablingUI()
    {
        _mainAbilityUI = _playerSetup.UIMainAbility;
        _secondaryAbilityUI = _playerSetup.UISecondaryAbility;

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
    }
}
