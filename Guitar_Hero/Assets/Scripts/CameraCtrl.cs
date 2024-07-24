using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public static CameraCtrl instance = null;

    public GameObject fps_camPos;
    public GameObject gui_camPos;
    public GameObject run_camPos;
    public GameObject frt_camPos;

    public GameObject unityChan;

    private Vector3 defPos;
    private Quaternion defRot;

    public CameraMode cm = CameraMode.def;

    public enum CameraMode
    {
        def,
        fps,
        gui,
        run,
        frt
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
        defPos = this.transform.position;
        defRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.instance.gameMode)
        {
            case GameManager.GameMode.free:
                if (Input.GetKeyDown(KeyCode.H) && GameManager.instance.startGame)
                {
                    cm = CameraMode.def;
                }

                if (Input.GetKeyDown(KeyCode.F) && GameManager.instance.startGame)
                {
                    cm = CameraMode.fps;
                }

                if (Input.GetKeyDown(KeyCode.G) && GameManager.instance.startGame)
                {
                    cm = CameraMode.gui;
                }

                if (Input.GetKeyDown(KeyCode.R) && GameManager.instance.startGame)
                {
                    cm = CameraMode.run;
                }

                if (Input.GetKeyDown(KeyCode.Q) && GameManager.instance.startGame)
                {
                    cm = CameraMode.frt;
                }

                break;

            case GameManager.GameMode.runner:
                if (GameManager.instance.startGame)
                {
                    if (unityChan.transform.position.z < -500 && unityChan.transform.position.z > -555)
                    {
                        cm = CameraMode.frt;
                    }
                    else
                    {
                        cm = CameraMode.run;
                    }
                }
                break;
        }

        switch (cm)
        {
            case CameraMode.def:
                this.transform.position = defPos;
                this.transform.rotation = defRot;
                break;

            case CameraMode.fps:
                this.transform.position = fps_camPos.transform.position;
                this.transform.rotation = fps_camPos.transform.rotation;
                break;

            case CameraMode.gui:
                this.transform.position = gui_camPos.transform.position;
                this.transform.rotation = gui_camPos.transform.rotation;
                break;

            case CameraMode.run:
                this.transform.position = run_camPos.transform.position;
                this.transform.rotation = run_camPos.transform.rotation;
                break;

            case CameraMode.frt:
                this.transform.position = frt_camPos.transform.position;
                this.transform.rotation = frt_camPos.transform.rotation;
                break;
        }
    }
}
