using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadMainMenu : ButtonBase
{
    void Start()
    {
        setupButton();
        _thisButton.onClick.AddListener(mainMenuLoad);
    }

    void mainMenuLoad()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
