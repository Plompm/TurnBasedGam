using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_particles : MonoBehaviour
{
    private ParticleSystem _fire;

    // Start is called before the first frame update
    void Start()
    {
        _fire = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (gameObject.GetComponentInParent<CharacterController>().velocity.x < 0)
        {
            var main = _fire.inheritVelocity;
            main.curveMultiplier = 1.06f;
        }
        else
        {
            var main = _fire.inheritVelocity;
            main.curveMultiplier = 0;
        }
        */
    }
}
