using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadEarthAttack : ButtonBase
{
    void Start()
    {
        setupButton();
        _thisButton.onClick.AddListener(earthAttackLoad);
    }

    void earthAttackLoad()
    {
        SceneManager.LoadScene("Attack_Earth");
    }
}
