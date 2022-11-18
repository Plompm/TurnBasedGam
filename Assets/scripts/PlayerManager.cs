using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    playerAction _givenState;
    GameObject _infoManager;

    void Start()
    {
        _givenState = GameObject.Find("infoManager").GetComponent<battleInfo>().PlayerInput;
        _infoManager = GameObject.Find("infoManager");

        if (_givenState == playerAction.FireAttack)
            gameObject.AddComponent<fireState>();
        if (_givenState == playerAction.AirAttack)
            gameObject.AddComponent<airState>();
        if (_givenState == playerAction.EarthAttack)
            gameObject.AddComponent<earthState>();
        if (_givenState == playerAction.WaterAttack)
            gameObject.AddComponent<waterState>();
        if (_givenState == playerAction.Run)
            gameObject.AddComponent<RunState>();
    }


    void Update()
    {

    }

    public void takeDamage(float damageDealt)
    {
        print("oww");
        _infoManager.GetComponent<battleInfo>().PlayerHealth -= damageDealt;
    }
}
