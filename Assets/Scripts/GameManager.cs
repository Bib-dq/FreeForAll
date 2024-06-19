using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates {inTitel, inGame, paused, hub};
    public GameStates state = GameStates.inTitel;    
    public static GameManager instance;
    public float GameTimer = 60;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }        
    }
    

    void Update()
    {
        if(state == GameStates.inGame)
        {
            GameTimer -= Time.deltaTime;
            Debug.Log(GameTimer);
            if(GameTimer <= 0)
            {
                SceneManager.LoadScene("Titel");
                state = GameStates.inTitel; 
                GameTimer = 60;
            }
        }

        if(Input.GetKey(KeyCode.Escape) && state == GameStates.inGame)
        {
            Pause.Instance.gameObject.SetActive(true);
        }
    }
    public static void GoToGame()
    {
        SceneManager.LoadScene("Game");
        instance.state = GameStates.inGame;
    }

    public static void GoToHub()
    {
        SceneManager.LoadScene("Hub");
        instance.state = GameStates.hub;
    }

    public static void GoToTitel()
    {
        SceneManager.LoadScene("Titel");
        instance.state = GameStates.inTitel;
    }
}
