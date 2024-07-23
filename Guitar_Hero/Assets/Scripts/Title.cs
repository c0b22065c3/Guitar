using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    private Text text;
    private float r = 1, g = 0, b = 0;

    const float DELTA = 0.01f;
    LArc lArc = LArc.red;

    public enum LArc
    {
        red,
        green,
        blue
    }

    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.color = new Color(r, g, b);

        switch (lArc)
        {
            case LArc.red:
                if (g < 1)
                {
                    g += DELTA;
                }
                else
                {
                    if (r > 0)
                    {
                        r -= DELTA;
                    }
                    else
                    {
                        lArc = LArc.green;
                    }
                }
                break;

            case LArc.green:
                if (b < 1)
                {
                    b += DELTA;
                }
                else
                {
                    if (g > 0)
                    {
                        g -= DELTA;
                    }
                    else
                    {
                        lArc = LArc.blue;
                    }
                }
                break;

            case LArc.blue:
                if (r < 1)
                {
                    r += DELTA;
                }
                else
                {
                    if (b > 0)
                    {
                        b -= DELTA;
                    }
                    else
                    {
                        lArc = LArc.red;
                    }
                }
                break;
        }
    }
}
