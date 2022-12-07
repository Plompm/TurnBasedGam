using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SoundSystem;

public class ButtonBase : MonoBehaviour
{
    protected Button _thisButton;
    // Update is called once per frame
    protected void setupButton()
    {
        _thisButton = gameObject.GetComponent<Button>();
    }
}
