using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float targetTime = 0f;
    public Minionstats statsM;
    
    void Start()
    {
        statsM = new Minionstats();
        targetTime = 0;   
    }

    
    void Update()
    {
        Vector3 playerPosition = Wizard.Instance.transform.position;
        Vector3 direction = playerPosition - transform.position;
        transform.position += direction.normalized*Time.deltaTime*statsM.speed;
        targetTime += Time.deltaTime;
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Projectile")
        {
            statsM.health -= Wizard.Stats.fireballDamage;
            if (statsM.health <= 0)
            {
                Destroy(collision2D.gameObject);
                Destroy(gameObject);
            }  
            return;
        }
        if(collision2D.gameObject.tag == "Player")
        {
            statsM.health -= Wizard.Stats.fireballDamage;
            if(Wizard.Instance.timer <= 0)
            {
                Wizard.Stats.health -= statsM.damage;
            }
            if (statsM.health <= 0)
            {
                Destroy(gameObject);
            }
            return;
        }
    }
    void OnDestroy()
    {
        HUD.score += 1;
        Wizard.Stats.GainXP(40 / targetTime);
    }
}
