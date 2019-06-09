using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSizeManager : MonoBehaviour
{
    public static Resolution currentResolution;
    void Awake()
    {
        // lấy kích thước màn hình
        GameSizeManager.currentResolution = Screen.currentResolution;
        Debug.Log(GameSizeManager.currentResolution);
    }
}