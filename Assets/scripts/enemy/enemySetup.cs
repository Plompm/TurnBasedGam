using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySetup : MonoBehaviour
{

    [SerializeField] public GameObject FlameThrower;
    [SerializeField] public GameObject FireBall;

    [SerializeField] public GameObject AirSlice;

    [SerializeField] public GameObject EarthWall;
    [SerializeField] public GameObject EarthDisk;

    [SerializeField] public GameObject WaterJet;
    [SerializeField] public GameObject IceCicle;

    [SerializeField] public Transform[] IceCicleSpawnPos;

    [SerializeField] public Transform SpawnPosition;
    [SerializeField] public Transform EarthWallSpawnPosition;
    [SerializeField] public Transform EarthDiskSpawnPosition;

    [SerializeField] public GameObject UIHealth;
}
