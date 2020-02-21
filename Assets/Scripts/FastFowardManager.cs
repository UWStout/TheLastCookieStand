using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FastFowardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFast = false;
    public Image fastButton;
    public Sprite fastSprite;
    public Sprite playSprite;

    public void Fast()
    {
        if (Time.timeScale>=.2f)
        {
            if (isFast)
            {
                fastButton.sprite= playSprite;

                isFast = false;
                Time.timeScale = 1;
            }
            else
            {
                fastButton.sprite=fastSprite;
                isFast = true;
                Time.timeScale = 2;
            }
        }

    }

    void Update()
    {
        if (Time.timeScale>=.2f)
        {
            if (isFast)
            {
                Time.timeScale = 2;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

    }
}
