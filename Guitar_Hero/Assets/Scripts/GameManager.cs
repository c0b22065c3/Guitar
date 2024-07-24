using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("ストローク時のフィードバック")] public float stroke;

    private string sceneName; // 現在のシーンの名前を格納する用
    private bool startGame = false;

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

        if (sceneName != "Title")
        {
            startGame = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stroke > 5 && sceneName == "Title")
        {
            SceneManager.LoadScene("Battle");
            startGame = true;
        }
    }

    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        sceneName = nextScene.name;
    }
}
