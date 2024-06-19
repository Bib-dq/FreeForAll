using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titel : MonoBehaviour
{
    // Start is called before the first frame update
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
    public void GoToHub()
    {
        GameManager.GoToHub();
    }
}
