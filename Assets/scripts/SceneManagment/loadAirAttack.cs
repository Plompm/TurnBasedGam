using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadAirAttack : ButtonBase
{
    void Start()
    {
        setupButton();
        _thisButton.onClick.AddListener(airAttackLoad);
    }

    void airAttackLoad()
    {
        GameObject.Find("infoManager").GetComponent<battleInfo>().PlayerInput = playerAction.AirAttack;
        SceneManager.LoadScene("Attack_Air"); 
    }
}
