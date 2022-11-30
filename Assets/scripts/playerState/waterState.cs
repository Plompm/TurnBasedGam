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

    GameObject _waterJet;
    GameObject _ActiveWaterJet;
    ParticleSystem _vfxWaterJet;
    GameObject _iceCicle;

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
        
        if (Input.GetMouseButtonDown(0))
        {
            bool justSpawned = false;
            if (_waterShooting == false)
            {
                _ActiveWaterJet = Instantiate(_waterJet, _spawnTransform.position, _spawnTransform.rotation, _spawnTransform);
                _vfxWaterJet = _ActiveWaterJet.GetComponent<ParticleSystem>();
                justSpawned = true;
                _waterShooting = true;
            }
            if (justSpawned == false && _waterShooting == true)
            {
                _waterShooting = false;
                _ActiveWaterJet.transform.parent = null;
                _ActiveWaterJet.GetComponent<waterJet>().Freeze = true;
                var trail = _vfxWaterJet.trails;
                trail.mode = ParticleSystemTrailMode.Ribbon;
                _vfxWaterJet.Pause();
                var COL = _vfxWaterJet.colorOverLifetime;
                COL.color = new Color(0,.75f,1,0.5f);
            }
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
