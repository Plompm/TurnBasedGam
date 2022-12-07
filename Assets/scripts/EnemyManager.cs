using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public enemyAction GivenState;
    GameObject _player;
    GameObject _infoManager;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _infoManager = GameObject.Find("infoManager");

        GivenState = GameObject.Find("infoManager").GetComponent<battleInfo>().AIInput;
        if (GivenState == enemyAction.FireAttack)
            gameObject.AddComponent<EnemyFire>();
        if (GivenState == enemyAction.AirAttack)
            gameObject.AddComponent<EnemyAir>();
        if (GivenState == enemyAction.EarthAttack)
            gameObject.AddComponent<EnemyEarth>();
        if (GivenState == enemyAction.WaterAttack)
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
