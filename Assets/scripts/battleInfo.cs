using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum playerAction {FireAttack, AirAttack, EarthAttack, WaterAttack }
public enum enemyAction {FireAttack, AirAttack, EarthAttack, WaterAttack }

public class battleInfo : MonoBehaviour
{
    public static battleInfo Instance;

    public float EnemyFireHealth;
    public float EnemyAirHealth;
    public float EnemyEarthHealth;
    public float EnemyWaterHealth;
    public float PlayerFireHealth;
    public float PlayerAirHealth;
    public float PlayerEarthHealth;
    public float PlayerWaterHealth;
    public playerAction PlayerInput;
    public enemyAction AIInput;

    Scene _checkScene;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        _checkScene = SceneManager.GetActiveScene();
        EnemyFireHealth = 100;
        EnemyAirHealth = 100;
        EnemyEarthHealth = 100;
        EnemyWaterHealth = 100;
        PlayerFireHealth = 100;
        PlayerAirHealth = 100;
        PlayerEarthHealth = 100;
        PlayerWaterHealth = 100;
    }

    private void Update()
    {
        if (_checkScene != SceneManager.GetActiveScene())
        {
            _checkScene = SceneManager.GetActiveScene();
            if (_checkScene.name == "TurnState")
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        if (EnemyFireHealth <= 0 && EnemyAirHealth <= 0 && EnemyEarthHealth <= 0 && EnemyWaterHealth <= 0)
        {
            EnemyFireHealth = 100;
            EnemyAirHealth = 100;
            EnemyEarthHealth = 100;
            EnemyWaterHealth = 100;
            PlayerFireHealth = 100;
            PlayerAirHealth = 100;
            PlayerEarthHealth = 100;
            PlayerWaterHealth = 100;
            gameObject.GetComponent<loadWin>().winLoad();
        }
        if (PlayerFireHealth <= 0 && PlayerAirHealth <= 0 && PlayerEarthHealth <= 0 && PlayerWaterHealth <= 0)
        {
            EnemyFireHealth = 100;
            EnemyAirHealth = 100;
            EnemyEarthHealth = 100;
            EnemyWaterHealth = 100;
            PlayerFireHealth = 100;
            PlayerAirHealth = 100;
            PlayerEarthHealth = 100;
            PlayerWaterHealth = 100;
            gameObject.GetComponent<loadLose>().loseLoad();
        }

    }

}
