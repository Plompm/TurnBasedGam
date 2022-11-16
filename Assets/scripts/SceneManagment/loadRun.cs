using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadRun : ButtonBase
{
    void Start()
    {
        setupButton();
        _thisButton.onClick.AddListener(runLoad);
    }

    void runLoad()
    {
        GameObject.Find("infoManager").GetComponent<battleInfo>().PlayerInput = playerAction.Run;
        SceneManager.LoadScene("Run");
    }
}
