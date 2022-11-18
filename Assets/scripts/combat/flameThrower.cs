using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flameThrower : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            print("DIe DIE DIE");
        }
    }
}
