using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    GameObject _enemy;
    public playerAction GivenState;
    public GameObject InfoManager;
    battleInfo _battleInfo;
    fireState _PF;
    airState _PA;
    earthState _PE;
    waterState _PW;

    float _enemyhealthToSend;

    void Awake()
    {
        InfoManager = GameObject.Find("infoManager");
        _enemy = GameObject.FindWithTag("Enemy");
        _battleInfo = InfoManager.GetComponent<battleInfo>();
        GivenState = GameObject.Find("infoManager").GetComponent<battleInfo>().PlayerInput;


        if (GivenState == playerAction.FireAttack)
            _PF = gameObject.AddComponent<fireState>();
        if (GivenState == playerAction.AirAttack)
            _PA = gameObject.AddComponent<airState>();
        if (GivenState == playerAction.EarthAttack)
            _PE = gameObject.AddComponent<earthState>();
        if (GivenState == playerAction.WaterAttack)
            _PW = gameObject.AddComponent<waterState>();
    }


    void Update()
    {
        if (GivenState == playerAction.FireAttack)
        {
            if (_PF.Health <= 0)
            {
                _battleInfo.PlayerFireHealth = _PF.Health;
                sendEnemyHealth();
                SceneManager.LoadScene("TurnState");
            }
        }
        if (GivenState == playerAction.AirAttack)
        {
            if (_PA.Health <= 0)
            {
                _battleInfo.PlayerAirHealth = _PA.Health;
                sendEnemyHealth();
                SceneManager.LoadScene("TurnState");
            }
        }
        if (GivenState == playerAction.EarthAttack)
        {
            if (_PE.Health <= 0)
            {
                _battleInfo.PlayerEarthHealth = _PE.Health;
                sendEnemyHealth();
                SceneManager.LoadScene("TurnState");
            }
        }
        if (GivenState == playerAction.WaterAttack)
        {
            if (_PW.Health <= 0)
            {
                _battleInfo.PlayerWaterHealth = _PW.Health;
                sendEnemyHealth();
                SceneManager.LoadScene("TurnState");
            }
        }

        gettingHealth();
    }

    void sendEnemyHealth()
    {

        if (_enemy.GetComponent<EnemyManager>().GivenState == enemyAction.FireAttack)
        {
            _battleInfo.EnemyFireHealth = _enemyhealthToSend;
        }
        if (_enemy.GetComponent<EnemyManager>().GivenState == enemyAction.AirAttack)
        {
            _battleInfo.EnemyAirHealth = _enemyhealthToSend;
        }
        if (_enemy.GetComponent<EnemyManager>().GivenState == enemyAction.EarthAttack)
        {
            _battleInfo.EnemyEarthHealth = _enemyhealthToSend;
        }
        if (_enemy.GetComponent<EnemyManager>().GivenState == enemyAction.WaterAttack)
        {
            _battleInfo.EnemyWaterHealth = _enemyhealthToSend;
        }
    }

    void gettingHealth()
    {

        if (_enemy.GetComponent<EnemyManager>().GivenState == enemyAction.FireAttack)
        {
            _enemyhealthToSend = _enemy.GetComponent<EnemyFire>().Health;
        }
        if (_enemy.GetComponent<EnemyManager>().GivenState == enemyAction.AirAttack)
        {
            _enemyhealthToSend = _enemy.GetComponent<EnemyAir>().Health;
        }
        if (_enemy.GetComponent<EnemyManager>().GivenState == enemyAction.EarthAttack)
        {
            _enemyhealthToSend = _enemy.GetComponent<EnemyEarth>().Health;
        }
        if (_enemy.GetComponent<EnemyManager>().GivenState == enemyAction.WaterAttack)
        {
            _enemyhealthToSend = _enemy.GetComponent<EnemyWater>().Health;
        }
    }
}
