using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class projectileMovement : Movement
{
    float _timer;

    private void Start()
    {

        _timer = Time.time + 3f;
    }

    private void FixedUpdate()
    {
        MoveProjectile();
    }

    void MoveProjectile()
    {
        //direction to be added later
        Vector3 FowardmoveOffset = transform.forward * _maxSpeed;

        _rb.MovePosition(_rb.position + FowardmoveOffset);
    }

    private void Update()
    {
        DestroyByTime();
    }

    void DestroyByTime()
    {
        if (_timer <= Time.time)
            Destroy(gameObject);
    }
}
