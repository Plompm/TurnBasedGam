using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnStateUI : MonoBehaviour
{
    [SerializeField] Slider _PF;
    [SerializeField] Slider _PA;
    [SerializeField] Slider _PE;
    [SerializeField] Slider _PW;
    [SerializeField] Slider _EF;
    [SerializeField] Slider _EA;
    [SerializeField] Slider _EE;
    [SerializeField] Slider _EW;

    [SerializeField] Button _fire;
    [SerializeField] Button _air;
    [SerializeField] Button _earth;
    [SerializeField] Button _water;

    GameObject _infoManager;
    battleInfo _battleInfo;

    // Start is called before the first frame update
    void Start()
    {
        _infoManager = GameObject.Find("infoManager");
        _battleInfo = _infoManager.GetComponent<battleInfo>();

        _PF.value = _battleInfo.PlayerFireHealth;
        _PA.value = _battleInfo.PlayerAirHealth;
        _PE.value = _battleInfo.PlayerEarthHealth;
        _PW.value = _battleInfo.PlayerWaterHealth;

        _EF.value = _battleInfo.EnemyFireHealth;
        _EA.value = _battleInfo.EnemyAirHealth;
        _EE.value = _battleInfo.EnemyEarthHealth;
        _EW.value = _battleInfo.EnemyWaterHealth;


    }

    // Update is called once per frame
    void Update()
    {
        if (_PF.value <= 0)
        {
            _fire.interactable = false;
        }
        else _fire.interactable = true;

        if (_PA.value <= 0)
        {
            _air.interactable = false;
        }
        else _air.interactable = true;

        if (_PE.value <= 0)
        {
            _earth.interactable = false;
        }
        else _earth.interactable = true;

        if (_PW.value <= 0)
        {
            _water.interactable = false;
        }
        else _water.interactable = true;
    }
}
