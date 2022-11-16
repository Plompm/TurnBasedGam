using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    float _shootTime = 0;
    RaycastHit _hit;
    [SerializeField] LayerMask player;
    GameObject _Player;

    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward * 20, out _hit, 100))
        {
            if (Time.time > _shootTime + 2)
            {
                _Player.GetComponent<PlayerManager>().takeDamage(25);
                _shootTime = Time.time;
            }
        }
    }
}
