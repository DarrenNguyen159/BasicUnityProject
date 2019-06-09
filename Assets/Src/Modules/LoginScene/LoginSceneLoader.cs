using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginSceneLoader : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Button startGameBtn;
    [SerializeField] private Image backPanel;
    void Start()
    {
        // loadGUICompleted = false;
        InitGUI();
    }

    void InitGUI()
    {
        // ẩn GUI
        backPanel.color = new Color(0, 0, 0, 1); // màu đen

        // Set Title
        titleText.text = GameConfig.Strings.GAME_NAME;
        startGameBtn.transform.GetChild(0).GetComponent<Text>().text = Localization.Text("start_game");
        startGameBtn.onClick.AddListener(this.ChangeScene);

        // Ẩn dần màn đen
        StartCoroutine(ToggleGUI(true));
    }

    void ChangeScene()
    {
        StartCoroutine(ChangeSceneEffect());
    }

    IEnumerator ToggleGUI(bool fading)
    {
        Debug.Log("Call");
        // hiện
        if (fading)
        {
            // mỗi frame
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // nhạt dần
                backPanel.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // ẩn
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // đen dần
                backPanel.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

    IEnumerator ChangeSceneEffect()
    {
        StartCoroutine(ToggleGUI(false));
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }
}
