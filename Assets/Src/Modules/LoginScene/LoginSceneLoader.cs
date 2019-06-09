using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginSceneLoader : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Button startGameBtn;
    [SerializeField] private Text startGameText;
    void Start()
    {
        // Set Title
        titleText.text = GameConfig.Strings.GAME_NAME;
        startGameText.text = GameConfig.Strings.DEV_NAME;
    }
}
