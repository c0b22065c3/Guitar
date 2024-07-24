using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject unityChan;
    public GameObject clearObj;

    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        text.enabled = false;

        clearObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startGame)
        {
            if (!GameManager.instance.freezeUnityChan)
            {
                text.text = "Žc‚è " + (1000 + (int)unityChan.transform.position.z) + "m";
            }

            if (!GameManager.instance.goalGame)
            {
                text.enabled = true;
            }
            else
            {
                text.enabled = false;
            }
        }

        if (GameManager.instance.goalGame)
        {
            clearObj.SetActive(true);
        }
    }
}
