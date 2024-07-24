using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("�X�g���[�N���̃t�B�[�h�o�b�N")] public float stroke;

    private string sceneName; // ���݂̃V�[���̖��O���i�[����p
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
        // ���݂̃V�[���̖��O���i�[
        sceneName = SceneManager.GetActiveScene().name;

        //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h��o�^
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
