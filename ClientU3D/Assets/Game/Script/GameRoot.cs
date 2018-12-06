using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore;

public class GameRoot : MonoBehaviour
{
    void Awake()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);

        GameConfig.binPath = Application.streamingAssetsPath;
        GameLog.SetPrintHandler(UnityEngine.Debug.LogFormat);
        GameContext.InitGame();
    }

    void Start()
    {
        GameContext.StartGame();
    }

    void Update()
    {
        GameContext.TickGame();
    }

    void OnDestroy()
    {
        GameContext.QuitGame();
    }
}
