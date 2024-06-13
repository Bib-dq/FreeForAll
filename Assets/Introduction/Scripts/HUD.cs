using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public TMP_Text playername;
    public TMP_Text levelanzeige;
    public TMP_Text erfahrungspunkte;
    public TMP_Text skillPoint;
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public TMP_Text manaText;
    public Image manaImage;
    public Image healthImage;
    public Image expImage;
    public static int score = 0;
    public string namePlayer = "";
    
    void Start()
    {
        
    }

    void Update()
    {
        Playerstats s = Wizard.Stats;
        float MaxMana = s.MaxMana;
        int MaxHealth = s.MaxHealth;
        float mana = s.mana;
        float health = s.health;
        int level = s.level;
        int skillPointer = s.skillPoints;
        float exp = s.erfahrungspunkt;
        float nFL = s.needForLevel;

        levelanzeige.text = "Level: " + level;
        erfahrungspunkte.text = "Erfahrungspunkte:";
        playername.text = "Name: " + namePlayer;
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + Mathf.Round(health) + "/" + MaxHealth;
        manaText.text = "Mana: " + Mathf.Round(mana) + "/" + MaxMana;
        if(skillPointer > 0){
            skillPoint.text = "Skill Punkte: " + skillPointer;
        } else {
            skillPoint.text = "";
        }
        
        float manaPercantage = mana / MaxMana;
        manaImage.transform.localScale = new Vector3(manaPercantage, 1,1 );

        float healthPercantage = health / MaxHealth;
        healthImage.transform.localScale = new Vector3(healthPercantage, 1,1 );

        float expPercantage = exp / nFL;
        expImage.transform.localScale = new Vector3(expPercantage, 1,1 );

    }
}
