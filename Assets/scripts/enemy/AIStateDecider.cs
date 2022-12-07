using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateDecider : MonoBehaviour
{
    GameObject _infoManager;

    public float _enemyFireHealth;
    public float _enemyAirHealth;
    public float _enemyEarthHealth;
    public float _enemyWaterHealth;
    public float _playerFireHealth;
    public float _playerAirHealth;
    public float _playerEarthHealth;
    public float _playerWaterHealth;

    // Start is called before the first frame update
    void Start()
    {
        _infoManager = GameObject.Find("infoManager");
        getHealth();
        ChooseState();
    }

    void ChooseState()
    {
        int num = Random.Range(0, 4);
        if (num == 0)
        {
            baseFire();
        }
        if (num == 1)
        {
            baseAir();
        }
        if (num == 2)
        {
            baseEarth();
        }
        if (num == 3)
        {
            baseWater();
        }
    }

    void getHealth()
    {
        _enemyFireHealth = _infoManager.GetComponent<battleInfo>().EnemyFireHealth;
        _enemyAirHealth = _infoManager.GetComponent<battleInfo>().EnemyAirHealth;
        _enemyEarthHealth = _infoManager.GetComponent<battleInfo>().EnemyEarthHealth;
        _enemyWaterHealth = _infoManager.GetComponent<battleInfo>().EnemyWaterHealth;
        _playerFireHealth = _infoManager.GetComponent<battleInfo>().PlayerFireHealth;
        _playerAirHealth = _infoManager.GetComponent<battleInfo>().PlayerAirHealth;
        _playerEarthHealth = _infoManager.GetComponent<battleInfo>().PlayerEarthHealth;
        _playerWaterHealth = _infoManager.GetComponent<battleInfo>().PlayerWaterHealth;
    }

    void baseFire()
    {
        if (_enemyFireHealth <= 0)
        {
            if (_enemyAirHealth <= 0)
            {
                if (_enemyEarthHealth <= 0)
                {
                    _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.WaterAttack;
                }
                else
                {
                    _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.EarthAttack;
                }
            }
            else
            {
                _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.AirAttack;
            }
        }
        else
        {
            _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.FireAttack; 
        }
    }
    void baseAir()
    {
        if (_enemyAirHealth <= 0)
        {
            if (_enemyEarthHealth <= 0)
            {
                if (_enemyWaterHealth <= 0)
                {
                    _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.FireAttack;
                }
                else
                {
                    _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.WaterAttack;
                }
            }
            else
            {
                _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.EarthAttack;
            }
        }
        else
        {
            _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.AirAttack;
        }
    }
    void baseEarth()
    {
        if (_enemyEarthHealth <= 0)
        {
            if (_enemyWaterHealth <= 0)
            {
                if (_enemyFireHealth <= 0)
                {
                    _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.AirAttack;
                }
                else
                {
                    _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.FireAttack;
                }
            }
            else
            {
                _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.WaterAttack;
            }
        }
        else
        {
            _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.EarthAttack;
        }
    }
    void baseWater()
    {
        if (_enemyWaterHealth <= 0)
        {
            if (_enemyFireHealth <= 0)
            {
                if (_enemyAirHealth <= 0)
                {
                    _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.EarthAttack;
                }
                else
                {
                    _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.AirAttack;
                }
            }
            else
            {
                _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.FireAttack;
            }
        }
        else
        {
            _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.WaterAttack;
        }
    }
}
