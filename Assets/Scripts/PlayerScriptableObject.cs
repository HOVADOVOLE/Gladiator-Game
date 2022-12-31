using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    public float hp = 0;
    public float dmg = 0;
    public float defense = 0;
    public int lvl = 1;
    public float acualHp = 0;
    public float xp = 0;
    public float xpToNxtLvl = 0;

    public int hpPoints = 5;
    public int dmgPoints = 25;
    public int defensePoints = 5;
    public int availablePoints = 5;

    public int money = 10;
    public int potionsAvailable = 1;

    public bool levlUp = false;

    public void UpdateAtributes()
    {
        hp = 20 * hpPoints;
        dmg = 10 * dmgPoints;
        defense = 5 * defensePoints;
        acualHp = hp;
    }
    public void DeleteAtributes()
    {
        hp = 0;
        dmg = 0;
        defense = 0;
        lvl = 1;

        acualHp = 0;
        xp = 0;
        xpToNxtLvl = 200;

        hpPoints = 5;
        dmgPoints = 25;
        defensePoints = 5;
        availablePoints = 0;

        levlUp= false;
        money = 10;
    }
}
