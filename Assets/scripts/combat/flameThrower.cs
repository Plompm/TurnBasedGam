using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameThrower : MonoBehaviour
{
    GameObject _spawner;
    CapsuleCollider _capCol;
    Vector3 _startPos;
    Vector3 _shrinkPos;
    float _startHeight;
    float _shrinkHeight;
    Vector3 _startScale;
    Vector3 _shrinkScale;

    private void Awake()
    {
        _capCol = gameObject.GetComponent<CapsuleCollider>();
        _startPos = _capCol.center;
        _shrinkPos = new Vector3(0, 0, 4);
        _startHeight = _capCol.height;
        _shrinkHeight = 8;
        _startScale = gameObject.transform.localScale;
        _shrinkScale = new Vector3(1, 1, 0.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Flame Thrower
        if (other.gameObject.layer == 7)
        {
            gameObject.transform.localScale = _shrinkScale;
        }

        //earthWall
        if (other.gameObject.layer == 10)
        {
            _capCol.center = _shrinkPos;
            _capCol.height = _shrinkHeight;
        }

        //waterJet
        if (other.gameObject.layer == 12)
        {
            gameObject.transform.localScale = _shrinkScale;
        }

        //only hurt enemy
        if (_spawner.tag == "Player")
        {

        }

        //only hurt player
        if (_spawner.tag == "Enemy")
        {

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //walls
        if (other.gameObject.layer == 10)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 10)
        {
            _capCol.center = _startPos;
            _capCol.height = _startHeight;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //earthwall
        if (other.gameObject.layer == 10)
        {
            _capCol.center = _startPos;
            _capCol.height = _startHeight;
        }
        //Flame Thrower
        if (other.gameObject.layer == 7)
        {
            gameObject.transform.localScale = _startScale;
        }
        //waterJet
        if (other.gameObject.layer == 12)
        {
            gameObject.transform.localScale = _startScale;
        }
    }
    public void getSpawner(GameObject spawner)
    {
        _spawner = spawner;
    }
}
