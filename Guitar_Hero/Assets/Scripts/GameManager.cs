using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("ゲームモード")] public GameMode gameMode;
    [Header("音量の閾値")] public float threshold;

    [Header("ストローク時のフィードバック")] public float stroke;
    [Header("ゲームスタート")] public bool startGame = false;

    private string sceneName; // 現在のシーンの名前を格納する用

    public enum GameMode
    {
        free,
        runner
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 現在のシーンの名前を格納
        sceneName = SceneManager.GetActiveScene().name;

        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startGame)
        {
            if (stroke > threshold)
            {
                startGame = true;
            }
        }
        else
        {
            switch (gameMode)
            {
                case GameMode.free:
                    break;

                case GameMode.runner:
                    break;
            }
        }

    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        sceneName = nextScene.name;
    }
}
