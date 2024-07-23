using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public GameObject camPos;

    private Vector3 defPos;
    private Quaternion defRot;

    private bool FPS;

    // Start is called before the first frame update
    void Start()
    {
        defPos = this.transform.position;
        defRot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            FPS = true;
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            FPS = false;
        }

        if (FPS)
        {
            this.transform.position = camPos.transform.position;
            this.transform.rotation = camPos.transform.rotation;
        }
        else
        {
            this.transform.position = defPos;
            this.transform.rotation = defRot;
        }
    }
}
