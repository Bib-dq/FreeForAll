using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static GameObject Instance;
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void GoToTitel()
    {
        GameManager.GoToTitel();
    }

    public void Continue()
    {
        gameObject.SetActive(false);
    }

    public void GoPause() 
    { 
        gameObject.SetActive(true);
    }
}
