using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToGame()
    {
        GameManager.GoToGame();
    }

    public void GoToNewGame()
    {
        Wizard.Stats = new Playerstats();
        GameManager.GoToGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
