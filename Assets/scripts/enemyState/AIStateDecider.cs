using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateDecider : MonoBehaviour
{
    GameObject _infoManager;

    // Start is called before the first frame update
    void Start()
    {
        _infoManager = GameObject.Find("infoManager");
        ChooseState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChooseState()
    {
        int num = 0;
        if(_infoManager.GetComponent<battleInfo>().EnemyHealth >= 50)
        {
           num = Random.Range(0, 5);
        }
        if (_infoManager.GetComponent<battleInfo>().EnemyHealth < 50)
        {
            num = Random.Range(0, 4);
        }

        if (num == 0)
        {
            _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.FireAttack;
        }
        if (num == 1)
        {
            _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.AirAttack;
        }
        if (num == 2)
        {
            _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.EarthAttack;
        }
        if (num == 3)
        {
            _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.WaterAttack;
        }
        if (num == 4)
        {
            _infoManager.GetComponent<battleInfo>().AIInput = enemyAction.Block;
        }

    }
}
