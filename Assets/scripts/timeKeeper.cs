using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeKeeper : MonoBehaviour
{
    [SerializeField] GameObject _UITimer;
    float _time;

    void Start()
    {
        _UITimer.GetComponent<Image>().fillAmount = 1;
        _time = Time.time + 10;
    }

    private void Update()
    {
        if (_time <= Time.time)
        {
            gameObject.GetComponent<loadTurnState>().turnStateLoad();
        }
        if (_time >= Time.time)
        {
            _UITimer.GetComponent<Image>().fillAmount = Mathf.Clamp01((_time - Time.time)/10);
        }
    }
}
