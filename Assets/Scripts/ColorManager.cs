using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public readonly Color white = new Color(1, 1, 1);
    public readonly Color red = new Color(1, 0, 0);
    public readonly Color green = new Color(0, 1, 0);
    public readonly Color blue = new Color(0, 0, 1);

    public readonly Color darkGreen = new Color(0, 0.5f, 0);
    public readonly Color purple = new Color(0.5f, 0, 0.5f);
    public readonly Color yellow = new Color(1, 1, 0);
    public readonly Color orange = new Color(1, 0.5f, 0);

    private static ColorManager colorManager;

    private void Awake()
    {
        if (colorManager == null)
        {
            colorManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public Color CombineColors(Color color1, Color color2)
    {
        color1 = RoundColorValues(color1);
        color2 = RoundColorValues(color2);

        List<Color> colorList = new List<Color>();
        colorList.Add(color1);
        colorList.Add(color2);

        if (colorList.Contains(blue))
        {
            if (colorList.Contains(red))
            {
                return purple; 
            }
            if (colorList.Contains(yellow))
            {
                return darkGreen;
            }
            return Color.blue;
        }

        if (colorList.Contains(red))
        {
            if (colorList.Contains(yellow))
            {
                return orange;
            }
            return red;
        }

        if (colorList.Contains(yellow))
        {
            return yellow;
        }

        return Color.gray;
    }

    private Color RoundColorValues(Color color)
    {
        float newR = (float)System.Math.Round(color.r, 2);
        float newG = (float)System.Math.Round(color.g, 2);
        float newB = (float)System.Math.Round(color.b, 2);

        return new Color(newR, newG, newB);
    }
}





/* ---- COLOR GUIDE ----

RED: 1, 0, 0
GREEN: 0, 1, 0
BLUE: 0, 0, 1

CYAN:
MAGENTA:
YELLOW: 1, 1, 0

PURPLE: 0.5, 0, 0.5



COLOR COMBINATIONS

RED + BLUE == PURPLE
RED + YELLOW == ORANGE
BLUE + YELLOW == DARKGREEN

*/