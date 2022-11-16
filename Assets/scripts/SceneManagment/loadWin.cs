using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadWin : ButtonBase
{
    void Start()
    {
        if (gameObject.name != "infoManager")
        {
            setupButton();
            _thisButton.onClick.AddListener(winLoad);
        }
    }

    public void winLoad()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Win");
    }
}
