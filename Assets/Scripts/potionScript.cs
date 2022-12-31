using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts;

public class potionScript : MonoBehaviour
{
    [SerializeField] TMP_Text ammount;
    [SerializeField] PlayerScriptableObject playerScriptable;
    int amm;
    Player player;
    //[SerializeField] PlayerScriptableObject player;

    void Start()
    {
        amm = playerScriptable.potionsAvailable;
        player = gameObject.GetComponent<Player>();
        Rewrite();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha2) && amm > 0 && player.acualHp != player.Hp)
        {
            AddHp();
        }
    }
    void Rewrite()
    {
        ammount.text = amm.ToString();
        playerScriptable.potionsAvailable = amm;
    }
    void AddHp()
    {
        amm--;

        if (player.acualHp > player.Hp * 0.66f)
        {
            player.acualHp = player.Hp;
        }
        else
        {
            player.acualHp += player.Hp / 3;
        }

        Rewrite();
    }
}
