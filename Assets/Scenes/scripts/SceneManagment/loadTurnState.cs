using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadTurnState : ButtonBase
{
    void Start()
    {
        setupButton();
        _thisButton.onClick.AddListener(turnStateLoad);
    }

    void turnStateLoad()
    {
        SceneManager.LoadScene("TurnState");
    }
}
