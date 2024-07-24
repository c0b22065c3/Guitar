using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private Text text;
    private int count = 3;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startGame)
        {
            if (count - (int)timer > 0)
            {
                text.enabled = true;

                text.text = "" + (count - (int)timer);
                GameManager.instance.freezeUnityChan = true;

                timer += Time.deltaTime;
            }
            else if (count - (int)timer > -1)
            {
                text.text = "GO!!!!!";
                GameManager.instance.freezeUnityChan = false;

                timer += Time.deltaTime;
            }
            else
            {
                text.enabled = false;
            }
        }
    }
}
