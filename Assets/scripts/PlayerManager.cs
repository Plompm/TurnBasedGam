﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    playerAction _givenState;

    void Start()
    {
        _givenState = GameObject.Find("infoManager").GetComponent<battleInfo>().PlayerInput;
        print(_givenState);
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
        if (_givenState == playerAction.Block)
            gameObject.AddComponent<BlockState>();
    }


    void Update()
    {

    }

    public void takeDamage(float damageDealt)
    {

    }
}
