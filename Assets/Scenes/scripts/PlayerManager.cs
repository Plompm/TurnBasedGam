using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{



    public bool islooking = true;


    float _timeCheck;

    // Start is called before the first frame update
    void Start()
    {
        islooking = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float damageDealt)
    {

    }

    void playerLose()
    {
        islooking = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
