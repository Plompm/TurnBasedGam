using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    GameObject _player;
    enemySetup _enemySetup;
    battleInfo _battleinfo;

    GameObject _flameThrowerRef;
    GameObject _flameThrower;
    Transform _spawnTransform;
    ParticleSystem _particleSystemFlameThrower;

    float maxFlameThrowerCharge = 3;
    float curFlameThrowerCharge;
    float _delayTimer;
    bool _delayFlamerOn;
    bool _flameThrowerOn;

    GameObject _FireBallRef;
    GameObject _activeFireBall;

    float _fireBallRechargeTime = 2;

    public float Health;
    float maxHealth = 100;

    float _fireBallRandomWaitTime;

    // Start is called before the first frame update
    void Start()
    {
        _battleinfo = gameObject.GetComponent<EnemyManager>().InfoManager.GetComponent<battleInfo>();
        _enemySetup = gameObject.GetComponent<enemySetup>();
        Health = _battleinfo.EnemyFireHealth;
        _flameThrowerRef = _enemySetup.FlameThrower;
        _FireBallRef = _enemySetup.FireBall;
        _spawnTransform = _enemySetup.SpawnPosition;
        setRandomTime();
        _player = gameObject.GetComponent<EnemyAI>().Player;
    }

    // Update is called once per frame
    void Update()
    {
        fireBallAttack();
        flameThrowerAttack();
    }
    void fireBallAttack()
    {
        if (_fireBallRandomWaitTime <= Time.time)
        {
            _activeFireBall = Instantiate(_FireBallRef, _spawnTransform.position, _spawnTransform.rotation);
            _activeFireBall.GetComponent<FireBall>().getSpawner(gameObject);
            setRandomTime();
        }
    }
    void flameThrowerAttack()
    {
        if (_delayFlamerOn == false)
        {
            if (Vector3.Distance(_player.transform.position, transform.position) <= 20)
            {
                if (_flameThrower == null)
                {
                    _flameThrower = Instantiate(_flameThrowerRef, _spawnTransform.position, _spawnTransform.rotation, _spawnTransform);
                    _flameThrower.GetComponent<flameThrower>().getSpawner(gameObject);
                    _particleSystemFlameThrower = _flameThrower.GetComponent<ParticleSystem>();
                }

                _flameThrower.GetComponent<CapsuleCollider>().enabled = true;
                _particleSystemFlameThrower.Play();
                _flameThrowerOn = true;
            }
            if (Vector3.Distance(_player.transform.position, transform.position) >= 25 && _flameThrowerOn == true)
            {
                _flameThrowerOn = false;
                _flameThrower.GetComponent<CapsuleCollider>().enabled = false;
                _particleSystemFlameThrower.Stop(true);
            }

            if (_flameThrowerOn == false)
            {
                curFlameThrowerCharge -= Time.deltaTime;
                curFlameThrowerCharge = Mathf.Clamp(curFlameThrowerCharge, 0, maxFlameThrowerCharge);

            }
            if (_flameThrowerOn == true)
            {
                curFlameThrowerCharge += Time.deltaTime;
                curFlameThrowerCharge = Mathf.Clamp(curFlameThrowerCharge, 0, maxFlameThrowerCharge);
            }

            if (curFlameThrowerCharge >= maxFlameThrowerCharge)
            {
                _delayFlamerOn = true;
                _delayTimer = Time.time + 1;
                _flameThrowerOn = false;
                _flameThrower.GetComponent<CapsuleCollider>().enabled = false;
                _particleSystemFlameThrower.Stop(true);
            }
        }

        if (_delayFlamerOn == true && _delayTimer <= Time.time)
        {
            _delayFlamerOn = false;
        }
    }

    void setRandomTime()
    {
        _fireBallRandomWaitTime = Time.time + Random.Range(3, 8);
    }

}
