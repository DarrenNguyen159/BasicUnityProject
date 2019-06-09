using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginSceneLoader : MonoBehaviour
{
    private bool loadGUICompleted;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Button startGameBtn;
    void Start()
    {
        loadGUICompleted = false;
    }

    private void Update() {
        if (!loadGUICompleted) {
            // đợi đến khi load xong localization
            if (Localization.loadCompleted) {
                InitGUI();
                loadGUICompleted = true;
                // load xong GUI
            }
        }
    }

    void InitGUI() {
        // Set Title
        titleText.text = GameConfig.Strings.GAME_NAME;
        startGameBtn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Localization.Text("start_game");
    }
}
