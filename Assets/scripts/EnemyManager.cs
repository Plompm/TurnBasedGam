using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    enemyAction _givenState;
    GameObject _player;
    GameObject _infoManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _infoManager = GameObject.Find("infoManager");

        _givenState = GameObject.Find("infoManager").GetComponent<battleInfo>().AIInput;
        if (_givenState == enemyAction.FireAttack)
            gameObject.AddComponent<EnemyFire>();
        if (_givenState == enemyAction.AirAttack)
            gameObject.AddComponent<EnemyAir>();
        if (_givenState == enemyAction.EarthAttack)
            gameObject.AddComponent<EnemyEarth>();
        if (_givenState == enemyAction.WaterAttack)
            gameObject.AddComponent<EnemyWater>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float damageDealt)
    {
        print("hit");
        _infoManager.GetComponent<battleInfo>().EnemyHealth -= damageDealt;
    }
}
