using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum playerAction { Run, Block, FireAttack, AirAttack, EarthAttack, WaterAttack }
public enum enemyAction { Block, FireAttack, AirAttack, EarthAttack, WaterAttack }

public class battleInfo : MonoBehaviour
{
    public static battleInfo Instance;

    public float EnemyHealth;
    public float PlayerHealth;
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
        EnemyHealth = 100;
        PlayerHealth = 100;
}

    private void Update()
    {
        if (_checkScene != SceneManager.GetActiveScene())
        {
            _checkScene = SceneManager.GetActiveScene();
        }
        if (EnemyHealth <= 0)
        {
            EnemyHealth = 100;
            PlayerHealth = 100;
            gameObject.GetComponent<loadWin>().winLoad();
        }
        if (PlayerHealth <= 0)
        {
            EnemyHealth = 100;
            PlayerHealth = 100;
            gameObject.GetComponent<loadLose>().loseLoad();
        }

    }

}
