using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [Header("�Q�[�����[�h")] public GameMode gameMode;
    [Header("���ʂ�臒l")] public float threshold;

    [Header("�X�g���[�N���̃t�B�[�h�o�b�N")] public float stroke;
    [Header("�Q�[���X�^�[�g")] public bool startGame = false;

    private string sceneName; // ���݂̃V�[���̖��O���i�[����p

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
        // ���݂̃V�[���̖��O���i�[
        sceneName = SceneManager.GetActiveScene().name;

        //�V�[�����؂�ւ�������ɌĂ΂�郁�\�b�h��o�^
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
