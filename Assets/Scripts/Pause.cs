using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(false);
        GameManager.instance.pauseMenu = this;
    }
    
    public void GoToTitel()
    {
        GameManager.GoToTitel();
    }

    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
        if (gameObject.activeSelf)
        {
            GameManager.instance.state = GameManager.GameStates.paused;
            Time.timeScale = 0;
        }
        else
        {
            GameManager.instance.state=GameManager.GameStates.inGame;
            Time.timeScale = 1;
        }
    }
}
