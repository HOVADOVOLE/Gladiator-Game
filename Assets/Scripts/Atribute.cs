using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Atribute : MonoBehaviour
{
    [SerializeField] Button addHp;
    [SerializeField] Button addDmg;
    [SerializeField] Button addDefense;
    [SerializeField] Button btnContinue;

    [SerializeField] TMP_Text lblHp;
    [SerializeField] TMP_Text lblDmg;
    [SerializeField] TMP_Text lblDefense;
    [SerializeField] TMP_Text lblAvaliable;

    [SerializeField] PlayerScriptableObject player;
    
    int avaliablePoints;
    int dmg = 0;
    int hp = 0;
    int defense = 0;

    private void Start()
    {
        dmg = player.dmgPoints;
        hp = player.hpPoints;
        defense = player.defensePoints;
        avaliablePoints = player.availablePoints;

        addHp.onClick.AddListener(AddSomeHp);
        addDmg.onClick.AddListener(AddSomeDmg);
        addDefense.onClick.AddListener(AddSomeDefense);
        btnContinue.onClick.AddListener(Continue);

        Rewrite();
    }
    void AddSomeHp()
    {
        if (Check() == true)
        {
            hp++;
            Rewrite();
        }
    }
    void AddSomeDmg()
    {
        if (Check() == true)
        {
            dmg++;
            Rewrite();
        }
    }
    void AddSomeDefense()
    {
        if (Check() == true)
        {
            defense++;
            Rewrite();
        }
    }
    bool Check()
    {
        if (avaliablePoints > 0)
        {
            avaliablePoints--;
            return true;
        }
        return false;
    }
    void Rewrite()
    {
        lblAvaliable.text = $"Available Points: {avaliablePoints}";
        lblHp.text = $"Health points: {hp}";
        lblDmg.text = $"Damage points: {dmg}";
        lblDefense.text = $"Defense points: {defense}";
    }
    void Continue()
    {
        Save();
        gameObject.SetActive(false);
    }
    void Save()
    {
        player.hpPoints = hp;
        player.dmgPoints = dmg;
        player.defensePoints = defense;
        player.availablePoints = avaliablePoints;

        player.UpdateAtributes();
        player.acualHp = player.hp;
    }
}
