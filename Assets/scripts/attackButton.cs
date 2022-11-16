using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class attackButton : ButtonBase
{
    [SerializeField] GameObject[] buttons;
    [SerializeField] TextMeshProUGUI _thisText;

    string attack = "Attack";
    string back = "Back";

    void Start()
    {
        setupButton();
        _thisButton.onClick.AddListener(changeButtons);
        _thisText.text = attack;
    }

    // Update is called once per frame
    void changeButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(!buttons[i].activeSelf);
        }
        if (_thisText.text == attack)
        {
            _thisText.text = back;
        }
        else if (_thisText.text == back)
        {
            _thisText.text = attack;
        }
    }
}
