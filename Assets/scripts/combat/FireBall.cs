using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SoundSystem;


public class FireBall : projectileMovement
{
    GameObject _spawner;
    float _damage = 20;
    [SerializeField]  GameObject Explosion;
    [SerializeField] SFXEvent _SFXexplosion;
    [SerializeField] SFXEvent _summon;

    private void OnTriggerEnter(Collider other)
    {
        //FireBall
        if (other.gameObject.layer == 8)
        {
            Utility.SpawnParticles(Explosion, gameObject, false);
            _SFXexplosion.Play();
            Destroy(gameObject);
        }

        //airSlice
        if (other.gameObject.layer == 9)
        {
            //grow and hurt all
        }

        //earthWall
        if (other.gameObject.layer == 10)
        {
            Utility.SpawnParticles(Explosion, gameObject, false);
            _SFXexplosion.Play();
            Destroy(gameObject);
        }
        //earthDisk
        if (other.gameObject.layer == 11)
        {
            Utility.SpawnParticles(Explosion, gameObject, false);
            _SFXexplosion.Play();
            Destroy(gameObject);
        }

        //waterJet
        if (other.gameObject.layer == 12)
        {
            Utility.SpawnParticles(Explosion, gameObject, false);
            _SFXexplosion.Play();
            Destroy(gameObject);
        }

        //only hurt enemy
        if (_spawner.tag == "Player")
        {
            if (other.tag == "Enemy")
            {
                Utility.SpawnParticles(Explosion, gameObject, false);
                _SFXexplosion.Play();
                findEnemyType(other.gameObject);
                Destroy(gameObject);
            }
        }

        //only hurt player
        if (_spawner.tag == "Enemy")
        {
            if (other.tag == "Player")
            {
                Utility.SpawnParticles(Explosion, gameObject, false);
                _SFXexplosion.Play();
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
            Utility.SpawnParticles(Explosion, gameObject, false);
            _SFXexplosion.Play();
            Destroy(gameObject);
        }
        //ground
        if (other.gameObject.layer == 6)
        {
            Utility.SpawnParticles(Explosion, gameObject, false);
            _SFXexplosion.Play();
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
