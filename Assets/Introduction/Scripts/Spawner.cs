using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    public GameObject[] enemyPrefab;
    private float timer = 5f;
    private float spawnIntervall = 4f;

    void Update()
    {
        if (GameManager.instance.state == GameManager.GameStates.paused)
        {
            return;
        }
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            float x = Random.Range(5,10) * ((Random.value>0.5) ? 1:-1);
            float y = Random.Range(5,10) * ((Random.value>0.5) ? 1:-1);
            Instantiate(enemyPrefab[0], new Vector3(x,y,0), Quaternion.identity);

            timer = spawnIntervall;
        }
    }
}
