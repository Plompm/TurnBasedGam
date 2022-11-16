using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    RaycastHit _hit;

    [SerializeField] LayerMask _shotIgnore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hit, 100, ~_shotIgnore))
            {
                if (_hit.transform.tag == "Enemy")
                {
                    _hit.transform.gameObject.GetComponentInParent<EnemyManager>().takeDamage(20);
                }
            }
        }
    }
}
