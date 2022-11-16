using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadBlock : ButtonBase
{
    void Start()
    {
        setupButton();
        _thisButton.onClick.AddListener(bloacLoad);
    }

    void bloacLoad()
    {
        GameObject.Find("infoManager").GetComponent<battleInfo>().PlayerInput = playerAction.Block;
        SceneManager.LoadScene("Block");
    }
}
