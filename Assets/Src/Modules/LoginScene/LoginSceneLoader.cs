using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginSceneLoader : MonoBehaviour
{
    [SerializeField] private Text titleText;
    void Start()
    {
        // Set Title
        titleText.text = GameConfig.Strings.DEV_NAME;
    }
}
