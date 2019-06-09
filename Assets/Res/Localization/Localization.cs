using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
/*
    String cho các ngôn ngữ và xử lý strings
 */
public class Localization : MonoBehaviour
{
    private SystemLanguage currentLanguage; // Ngôn ngữ của game
    private Dictionary<string, string> englishTexts;
    private Dictionary<string, string> vietnameseTexts;

    private void Start() {
        // Đặt ngôn ngữ là ngôn ngữ mặc định của thiết bị
        this.setLanguage(this.getDeviceLanguage());

        // Load text của các ngôn ngữ
        this.LoadLocalization();
    }

    // Hàm lấy text theo ngôn ngữ hiện tại
    public string Text(string key)
    {
        // Truy cập file
        string value = key;
        switch (this.currentLanguage) {
            case SystemLanguage.English:
                this.englishTexts.TryGetValue(key, out value);
                return value;
            case SystemLanguage.Vietnamese:
                return "Vie";
            default:
                return "Eng";
        }
    }

    // Hàm lấy ngôn ngữ của thiết bị
    public SystemLanguage getDeviceLanguage()
    {
        SystemLanguage lang = Application.systemLanguage;
        Debug.Log("Device Current Language is " + lang);
        return lang;
    }

    // Hàm set ngôn ngữ của game
    public void setLanguage(SystemLanguage lang)
    {
        this.currentLanguage = lang;
    }

    public void LoadLocalization () {
        Debug.Log("Loading localization ...");

        // Load tiếng anh
        englishTexts = new Dictionary<string, string>();
        this.LoadTextsOfLanguage(englishTexts, GameConfig.Paths.EN_PATH);

        // Load tiếng việt
        vietnameseTexts = new Dictionary<string, string>();
        this.LoadTextsOfLanguage(vietnameseTexts, GameConfig.Paths.VI_PATH);
    }

    private void LoadTextsOfLanguage(Dictionary<string, string> texts, string filepath) {
        StreamReader reader = new StreamReader(filepath);
        string line;
        while ((line = reader.ReadLine()) != null) {// đọc từng dòng
            // Debug.Log(line);
            string[] pair = line.Split('=');
            string key = pair[0].Trim();
            string value = pair[1].Trim();
            int valueLength = value.Length;
            int start = value.IndexOf('"');
            // Bỏ dấu " ở trước
            if (start == -1) {// lỗi format
                continue;
            }

            value = value.Substring(start + 1);

            int end = value.IndexOf('"');
            // Bỏ dấu " ở sau
            if (end == -1) {// lỗi format
                continue;
            }

            value = value.Remove(value.Length - 1);
            
            // xử lý \n
            int i = value.IndexOf("\\n");
            if (i != -1) {// có \n
                value = value.Replace("\\n", "\n");
            }
            
            texts.Add(key, value);
        }
    }
}