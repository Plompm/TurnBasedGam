using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    GameObject _player;
    void Start()
    {
        _player = gameObject.GetComponentInParent<EnemyAI>().Player;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform);
    }
}
