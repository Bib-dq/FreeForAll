using UnityEngine;

public class Playerstats
{
    public float movementspeed = 2.2f;
    public float fireRate = 1.5f;

    public int MaxHealth = 100;
    public float MaxMana = 100f;
    public float health = 100f;
    public float mana = 100f;
    public float fireballDamageManaCost = 5f;
    public float healthRegen = Time.deltaTime * 0.1f;
    public float manaRegen = Time.deltaTime * 0.3f;
    public static float minFireballDamage = 5f;
    public static float maxFireballDamage = 8f;
    public float fireballDamage = Random.Range(minFireballDamage, maxFireballDamage);
    public float needForLevel = 100f;

    public float erfahrungspunkt = 0f;
    public int level = 1;
    public int skillPoints = 0; 
    
    public void LevelUp()
    {
        level++;
        skillPoints++;
        SkillPointUse();
    }    

    public void SkillPointUse()
    {
        switch ((int)(Random.value*5))
        {
            case 0:        
            if(fireRate > 0.1f)
            {    
                fireRate -= 0.005f;
            } 
            else
            {
                fireRate += 0;
            }
            break;
            case 1:
            MaxHealth += 10;
            healthRegen += Time.deltaTime * 0.01f;
            break;
            case 2:            
            MaxMana += 5;
            manaRegen += Time.deltaTime * 0.05f; 
            break;
            case 3:
            movementspeed += 0.05f;
            break;
            case 4:
            minFireballDamage += 1f;
            maxFireballDamage += 1f;
            break;
        }
    }
    
    public void GainXP(float xp)
    {
        erfahrungspunkt += xp;
        if (erfahrungspunkt >= needForLevel){
            LevelUp();
            erfahrungspunkt = 0;
            needForLevel += 100;            
        }
    } 
}
