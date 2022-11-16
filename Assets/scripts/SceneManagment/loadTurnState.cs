using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadTurnState : ButtonBase
{
    void Start()
    {
        if (gameObject.name != "timeKeeper")
        {
            setupButton();
            _thisButton.onClick.AddListener(turnStateLoad);
        }
    }

    public void turnStateLoad()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("TurnState");
    }
}
