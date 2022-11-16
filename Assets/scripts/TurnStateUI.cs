using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnStateUI : MonoBehaviour
{
    [SerializeField] Slider _playerHealth;
    [SerializeField] Slider _enemyHealth;

    GameObject _infoManager;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth.interactable = false;
        _enemyHealth.interactable = false;

        _infoManager = GameObject.Find("infoManager");
        _playerHealth.value = _infoManager.GetComponent<battleInfo>().PlayerHealth;
        _enemyHealth.value = _infoManager.GetComponent<battleInfo>().EnemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
