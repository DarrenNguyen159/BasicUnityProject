using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginSceneLoader : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Button startGameBtn;
    void Start()
    {
        // loadGUICompleted = false;
        InitGUI();
    }

    void InitGUI()
    {
        // Set Title
        titleText.text = GameConfig.Strings.GAME_NAME;
        startGameBtn.transform.GetChild(0).GetComponent<Text>().text = Localization.Text("start_game");
        startGameBtn.onClick.AddListener(this.ChangeScene);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }
}
