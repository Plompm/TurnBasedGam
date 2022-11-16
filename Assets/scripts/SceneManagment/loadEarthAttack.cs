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
        GameObject.Find("infoManager").GetComponent<battleInfo>().PlayerInput = playerAction.EarthAttack;
        SceneManager.LoadScene("Attack_Earth");
    }
}
