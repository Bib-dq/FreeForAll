using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using Unity.VisualScripting;
using UnityEngine;

public class target : MonoBehaviour
{
    public GameObject targetPrefab;
    
    public float targetTime = 0f;
    public Minionstats statsM;
    
    void Start()
    {
        statsM = new Minionstats();
        targetTime = 0;   
    }

    void Update()
    {
        targetTime += Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {

        if (collision2D.gameObject.tag == "Projectile")
        {
            statsM.health -= Wizard.Stats.fireballDamage;
            if (statsM.health <= 0)
            {
                float x = 15.6f * Random.value - 7.8f;
                float y = 8f* Random.value - 4f;
                Instantiate(targetPrefab, new Vector3(x,y, 0f), Quaternion.identity);
                Destroy(gameObject);       
            }  
        }
    }

    void OnDestroy()
    {
        HUD.score += 1;
        Wizard.Stats.GainXP(40 / targetTime);
    }
}
