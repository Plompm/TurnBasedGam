using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLose : ButtonBase
{
    void Start()
    {
        if (gameObject.name != "infoManager")
        {
            setupButton();
            _thisButton.onClick.AddListener(loseLoad);
        }
    }

    public void loseLoad()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Lose");
    }
}
