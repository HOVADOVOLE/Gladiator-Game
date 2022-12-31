using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : Figure
{
    [SerializeField] PlayerScriptableObject playerScriptableObject;
    protected override void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 5)
        {
            if (playerScriptableObject.lvl > 1)
                lvl = Random.Range(playerScriptableObject.lvl - 1, playerScriptableObject.lvl + 2);
            else
                lvl = playerScriptableObject.lvl;

            dmg = Random.Range(playerScriptableObject.dmg * 0.1f, playerScriptableObject.dmg * 0.5f);
            defense = Random.Range(playerScriptableObject.defense * 0.5f, playerScriptableObject.defense);
            hp = Random.Range(playerScriptableObject.hp, playerScriptableObject.hp * 5);
        }
        else
        {
            lvl = 20;
            hp = 5000;
            defense = 100;
            dmg = 250;
        }
        acualHp = hp;
    }
}
