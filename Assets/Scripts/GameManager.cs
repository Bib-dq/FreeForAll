using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameStates {inTitel, inGame, paused};
    public GameStates state = GameStates.inTitel;    
    public static GameManager instance;
    public float GameTimer = 5;
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
                GameTimer = 5;
            }
        }

        Input.GetKey(KeyCode.Escape);
    }
    public static void GoToGame()
    {
        SceneManager.LoadScene("Game");
        instance.state = GameStates.inGame;
    }

}
