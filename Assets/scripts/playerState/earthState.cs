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

    [SerializeField] float Health;
    float maxHealth = 100;

    private void Awake()
    {
        enablingUI();
    }
    void Start()
    {
        Health = maxHealth;
        _spawnTransform = _playerSetup.SpawnPosition;
    }
        // Update is called once per frame
        void Update()
    {
        //primary Attack
        if (Input.GetMouseButtonDown(0))
        {
            print("earth Wall");
        }
        //secondary Attack
        if (Input.GetMouseButtonDown(1))
        {

        }

        UIUpdate();
    }
    void UIUpdate()
    {
        _UIhealth.GetComponent<Image>().fillAmount = Health / maxHealth;
        Health = Mathf.Clamp(Health, 0, maxHealth);
    }

    void enablingUI()
    {
        _playerSetup = gameObject.GetComponent<playerSetup>();
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
