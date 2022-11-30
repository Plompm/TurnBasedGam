using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterJet : MonoBehaviour
{
    bool _freeze;
    ParticleSystem _vfxWaterJet;
    float _timer;
    float t = 0;

    private void Awake()
    {
        _freeze = false;
        _vfxWaterJet = gameObject.GetComponent<ParticleSystem>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (_freeze == false)
            {
                print("hurt");
            }
            if (_freeze == true)
            {
                print("FREEZE");
            }
        }

    }

    public void FREEZE()
    {
        _timer = Time.time + 2;
        _freeze = true;
        var trail = _vfxWaterJet.trails;
        trail.mode = ParticleSystemTrailMode.Ribbon;
        _vfxWaterJet.Pause();
        var COL = _vfxWaterJet.colorOverLifetime;
        COL.color = new Color(0, .75f, 1, 0.5f);
    }

    private void Update()
    {
        if(_timer <= Time.time && _freeze == true)
        {
            var COL = _vfxWaterJet.colorOverLifetime;
            COL.color = new Color(0, .75f, 1, Mathf.Lerp(0.5f, 0f, t));
            t += 1.5f * Time.deltaTime;

            if (COL.color.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
