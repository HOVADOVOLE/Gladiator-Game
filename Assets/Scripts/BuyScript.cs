using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyScript : MonoBehaviour
{
    [SerializeField] PlayerScriptableObject player;
    [SerializeField] TMP_Text coins;
    List<Button> buyButtons = new List<Button>();
    int price;
    void Start()
    {
        buyButtons = GetComponentsInChildren<Button>(true).ToList();
        UpdateCoins();

        buyButtons[0].onClick.AddListener(Buy1);
        buyButtons[1].onClick.AddListener(Buy2);
        buyButtons[2].onClick.AddListener(Buy3);
        buyButtons[3].onClick.AddListener(Buy4);
        buyButtons[4].onClick.AddListener(Buy5);
        buyButtons[5].onClick.AddListener(BuyGalia);
    }
    void Buy1()
    {
        price = 10;
        BuyPotion(price);
    }
    void Buy2() 
    {
        price = 40;
        BuyWear(price, 5, 3, 10);
    }
    void Buy3()
    {
        price = 80;
        BuyWear(price, 10, 8, 30);
    }
    void Buy4()
    {
        price = 60;
        BuyWear(price, 15, 4, 15);
    }
    void Buy5()
    {
        price = 120;
        BuyWear(price, 40, 12, 25);
    }
    void BuyGalia()
    {
        price = 60;
        BuyWear(price, 120, 120, 120);
    }

    void BuyWear(int price, int dmg, int hp, int defense)
    {
        if(player.money >= price)
        {
            player.money -= price;

            player.dmgPoints += dmg;
            player.hpPoints += hp;
            player.defensePoints += defense;
            UpdateCoins();
        }
    }
    void BuyPotion(int price)
    {
        if(player.money >= price)
        {
            player.money -= price;
            player.potionsAvailable++;
            UpdateCoins();
        }
    }
    private void UpdateCoins()
    {
        coins.text = $"Coins: {player.money.ToString()}";
    }
}
