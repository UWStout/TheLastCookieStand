using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;
    public Image pauseButton;
    public Sprite pauseSprite;
    public Sprite playSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Image img;
        if (isPaused)
        {
            pauseButton.sprite=pauseSprite;
            isPaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseButton.sprite=playSprite;
            isPaused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}
