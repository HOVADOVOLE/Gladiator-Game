using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenu : MonoBehaviour
{
    [SerializeField] Button menu;
    [SerializeField] PlayerScriptableObject player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        menu.onClick.AddListener(ToMenu);
    }

    void ToMenu()
    {
        SceneManager.LoadScene(0);
        WipeOut();
    }

    void WipeOut()
    {
        player.hp = 0;
        player.dmg = 0;
        player.defense = 0;
        player.lvl = 1;
        player.acualHp = 0;
        player.xp = 0;
        player.xpToNxtLvl = 200;

        player.hpPoints = 5;
        player.dmgPoints = 25;
        player.defensePoints = 5;
        player.availablePoints = 0;
    }
}
