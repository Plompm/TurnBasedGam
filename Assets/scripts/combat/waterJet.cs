using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterJet : MonoBehaviour
{
    public bool Freeze;

    private void Awake()
    {
        Freeze = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (Freeze == false)
            {
                print("hurt");
            }
            if (Freeze == true)
            {
                print("FREEZE");
            }
        }

    }
}
