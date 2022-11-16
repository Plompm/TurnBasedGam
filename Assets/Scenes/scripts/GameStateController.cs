using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public static GameStateController Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void loadLevel_1()
    {
        SceneManager.LoadScene("level_01");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
