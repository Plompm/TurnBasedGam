using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    Material _MaterialToChange;

    // Start is called before the first frame update
    void Start()
    {
        _MaterialToChange = gameObject.GetComponentInChildren<MeshRenderer>().material;
        _MaterialToChange.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
