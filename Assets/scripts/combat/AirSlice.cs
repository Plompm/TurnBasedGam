using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;

public class AirSlice : projectileMovement
{
    GameObject _spawner;
    float _damage = 15;
    [SerializeField] GameObject _airBurst;
    [SerializeField] SFXEvent _summon;
    [SerializeField] SFXEvent _hit;
    private void OnTriggerEnter(Collider other)
    {
        //Flame Thrower
        if (other.gameObject.layer == 7)
        {
            Utility.SpawnParticles(_airBurst, gameObject, false);
            _hit.Play();
            Destroy(gameObject);
        }
        //FireBall
        if (other.gameObject.layer == 8)
        {
            Utility.SpawnParticles(_airBurst, gameObject, false);
            _hit.Play();
            Destroy(gameObject);
        }

        //airSlice
        if (other.gameObject.layer == 9)
        {
            Utility.SpawnParticles(_airBurst, gameObject, false);
            _hit.Play();
            Destroy(gameObject);
        }

        //earthWall
        if (other.gameObject.layer == 10)
        {
            Utility.SpawnParticles(_airBurst, gameObject, false);
            _hit.Play();
            Destroy(gameObject);
        }
        //earthDisk
        if (other.gameObject.layer == 11)
        {
            Utility.SpawnParticles(_airBurst, gameObject, false);
            _hit.Play();
            Destroy(gameObject);
        }

        //waterJet
        if (other.gameObject.layer == 12)
        {
            Utility.SpawnParticles(_airBurst, gameObject, false);
            _hit.Play();
            Destroy(gameObject);
        }
        //IceCicles
        if (other.gameObject.layer == 13)
        {
            Utility.SpawnParticles(_airBurst, gameObject, false);
            _hit.Play();
            Destroy(gameObject);
        }

        //only hurt enemy
        if (_spawner.tag == "Player")
        {
            if (other.tag == "Enemy")
            {
                Utility.SpawnParticles(_airBurst, gameObject, false);
                _hit.Play();
                findEnemyType(other.gameObject);
                Destroy(gameObject);
            }
        }

        //only hurt player
        if (_spawner.tag == "Enemy")
        {
            if (other.tag == "Player")
            {
                Utility.SpawnParticles(_airBurst, gameObject, false);
                _hit.Play();
                findPlayerType(other.gameObject);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //walls
        if (other.gameObject.layer == 10)
        {
            Utility.SpawnParticles(_airBurst, gameObject, false);
            _hit.Play();
            Destroy(gameObject);
        }
        //ground
        if (other.gameObject.layer == 6)
        {
            Utility.SpawnParticles(_airBurst, gameObject, false);
            _hit.Play();
            Destroy(gameObject);
        }
    }

    public void getSpawner(GameObject spawner)
    {
        _summon.Play();
        _spawner = spawner;
    }

    void findEnemyType(GameObject other)
    {
        if (other.gameObject.GetComponent<EnemyManager>().GivenState == enemyAction.FireAttack)
        {
            other.GetComponent<EnemyFire>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<EnemyManager>().GivenState == enemyAction.AirAttack)
        {
            other.GetComponent<EnemyAir>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<EnemyManager>().GivenState == enemyAction.EarthAttack)
        {
            other.GetComponent<EnemyEarth>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<EnemyManager>().GivenState == enemyAction.WaterAttack)
        {
            other.GetComponent<EnemyWater>().Health -= _damage;
        }
    }

    void findPlayerType(GameObject other)
    {
        if (other.gameObject.GetComponent<PlayerManager>().GivenState == playerAction.FireAttack)
        {
            other.GetComponent<fireState>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<PlayerManager>().GivenState == playerAction.AirAttack)
        {
            other.GetComponent<airState>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<PlayerManager>().GivenState == playerAction.EarthAttack)
        {
            other.GetComponent<earthState>().Health -= _damage;
        }
        if (other.gameObject.GetComponent<PlayerManager>().GivenState == playerAction.WaterAttack)
        {
            other.GetComponent<waterState>().Health -= _damage;
        }
    }
}
