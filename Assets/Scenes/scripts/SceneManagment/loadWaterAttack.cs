using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadWaterAttack : ButtonBase
{
    void Start()
    {
        setupButton();
        _thisButton.onClick.AddListener(waterAttackLoad);
    }

    void waterAttackLoad()
    {
        SceneManager.LoadScene("Attack_Water");
    }
}
