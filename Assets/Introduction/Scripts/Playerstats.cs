using UnityEngine;

public class Playerstats
{
    public float movementspeed = 2.0f;
    public float fireRate = 1.5f;

    public int MaxHealth = 100;
    public float MaxMana = 100f;
    public float health = 100f;
    public float mana = 100f; 
    public float healthRegen = Time.deltaTime * 0.1f;
    public float manaRegen = Time.deltaTime * 0.3f;
    public float fireballDamage = 5f;
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
            fireballDamage += 1f;
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
