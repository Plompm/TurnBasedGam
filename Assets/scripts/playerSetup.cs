using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSetup : MonoBehaviour
{

    [SerializeField] public GameObject FlameThrower;
    [SerializeField] public GameObject FireBall;

    [SerializeField] public GameObject AirSlice;

    [SerializeField] public GameObject EarthWall;
    [SerializeField] public GameObject EarthDisk;

    [SerializeField] public GameObject WaterJet;
    [SerializeField] public GameObject IceCicle;

    [SerializeField] public Transform[] IceCicleSpawnPos;

    [SerializeField] public GameObject[] UItoChange;

    [SerializeField] public Transform SpawnPosition;
    [SerializeField] public Transform EarthWallSpawnPosition;
    [SerializeField] public Transform EarthDiskSpawnPosition;
    [SerializeField] public GameObject UIMainAbility;
    [SerializeField] public GameObject UISecondaryAbility;
    [SerializeField] public GameObject UIFireMA;
    [SerializeField] public GameObject UIFireSA;
    [SerializeField] public GameObject UIAirMA;
    [SerializeField] public GameObject UIAirSA;
    [SerializeField] public GameObject UIMainAbilityInUse;
    [SerializeField] public GameObject UISecondAbilityinUse;
    [SerializeField] public GameObject UIEarthMA;
    [SerializeField] public GameObject UIEarthSA;
    [SerializeField] public GameObject UIWaterMA;
    [SerializeField] public GameObject UIWaterSA;

    [SerializeField] public GameObject[] TopElementalUI;
    [SerializeField] public GameObject UIHealth;

}
