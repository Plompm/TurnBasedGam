using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public enemyAction GivenState;
    GameObject _player;
    public GameObject InfoManager;
    battleInfo _battleInfo;
    EnemyFire _EF;
    EnemyAir _EA;
    EnemyEarth _EE;
    EnemyWater _EW;

    float _quickTime;
    float _playerHealthToSend;
    // Start is called before the first frame update
    void Awake()
    {
        InfoManager = GameObject.Find("infoManager");
        _battleInfo = InfoManager.GetComponent<battleInfo>();
        _player = GameObject.FindGameObjectWithTag("Player");


        GivenState = GameObject.Find("infoManager").GetComponent<battleInfo>().AIInput;

        if (GivenState == enemyAction.FireAttack)
        {
           _EF = gameObject.AddComponent<EnemyFire>();
        }
        if (GivenState == enemyAction.AirAttack)
        {
            _EA = gameObject.AddComponent<EnemyAir>();
        }
        if (GivenState == enemyAction.EarthAttack)
        {
            _EE = gameObject.AddComponent<EnemyEarth>();
        }
        if (GivenState == enemyAction.WaterAttack)
        {
            _EW = gameObject.AddComponent<EnemyWater>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (GivenState == enemyAction.FireAttack)
        {
            if (_EF.Health <= 0)
            {
                _battleInfo.EnemyFireHealth = _EF.Health;
                sendPlayerHealth();
                SceneManager.LoadScene("TurnState");
            }
        }
        if (GivenState == enemyAction.AirAttack)
        {
            if (_EA.Health <= 0)
            {
                _battleInfo.EnemyAirHealth = _EA.Health;
                sendPlayerHealth();
                SceneManager.LoadScene("TurnState");
            }
        }
        if (GivenState == enemyAction.EarthAttack)
        {
            if (_EE.Health <= 0)
            {
                _battleInfo.EnemyEarthHealth = _EE.Health;
                sendPlayerHealth();
                SceneManager.LoadScene("TurnState");
            }
        }
        if (GivenState == enemyAction.WaterAttack)
        {
            if (_EW.Health <= 0)
            {
                _battleInfo.EnemyWaterHealth = _EW.Health;
                sendPlayerHealth();
                SceneManager.LoadScene("TurnState");
            }
        }
        gettingHealth();
    }

    void sendPlayerHealth()
    {

        if (_player.GetComponent<PlayerManager>().GivenState == playerAction.FireAttack)
        {
            _battleInfo.PlayerFireHealth = _playerHealthToSend;
        }
        if (_player.GetComponent<PlayerManager>().GivenState == playerAction.AirAttack)
        {
            _battleInfo.PlayerAirHealth = _playerHealthToSend;
        }
        if (_player.GetComponent<PlayerManager>().GivenState == playerAction.EarthAttack)
        {
            _battleInfo.PlayerEarthHealth = _playerHealthToSend;
        }
        if (_player.GetComponent<PlayerManager>().GivenState == playerAction.WaterAttack)
        {
            _battleInfo.PlayerWaterHealth = _playerHealthToSend;
        }
    }

    void gettingHealth()
    {
        if (_player.GetComponent<PlayerManager>().GivenState == playerAction.FireAttack)
        {
            _playerHealthToSend = _player.GetComponent<fireState>().Health;
        }
        if (_player.GetComponent<PlayerManager>().GivenState == playerAction.AirAttack)
        {
            _playerHealthToSend = _player.GetComponent<airState>().Health;
        }
        if (_player.GetComponent<PlayerManager>().GivenState == playerAction.EarthAttack)
        {
            _playerHealthToSend = _player.GetComponent<earthState>().Health;
        }
        if (_player.GetComponent<PlayerManager>().GivenState == playerAction.WaterAttack)
        {
            _playerHealthToSend = _player.GetComponent<waterState>().Health;
        }
    }
}
