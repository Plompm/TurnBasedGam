using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirSlice : projectileMovement
{
    GameObject _spawner;
    private void OnTriggerEnter(Collider other)
    {
        //Flame Thrower
        if (other.gameObject.layer == 7)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }
        //FireBall
        if (other.gameObject.layer == 8)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }

        //airSlice
        if (other.gameObject.layer == 9)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }

        //earthWall
        if (other.gameObject.layer == 10)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }
        //earthDisk
        if (other.gameObject.layer == 11)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }

        //waterJet
        if (other.gameObject.layer == 12)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }
        //IceCicles
        if (other.gameObject.layer == 13)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }

        //only hurt enemy
        if (_spawner.tag == "Player")
        {
            if (other.tag == "Enemy")
            {
                //vfx
                //audio
                Destroy(gameObject);
            }
        }

        //only hurt player
        if (_spawner.tag == "Enemy")
        {
            if (other.tag == "Player")
            {
                //vfx
                //audio
                Destroy(gameObject);
            }
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
        //ground
        if (other.gameObject.layer == 10)
        {
            //vfx
            //audio
            Destroy(gameObject);
        }
    }

    public void getSpawner(GameObject spawner)
    {
        _spawner = spawner;
    }
}