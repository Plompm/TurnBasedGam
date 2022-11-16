using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class loadFireAttack : ButtonBase
{
    void Start()
    {
        setupButton();
        _thisButton.onClick.AddListener(fireAttackLoad);
    }

    void fireAttackLoad()
    {
        SceneManager.LoadScene("Attack_Fire");
    }
}
