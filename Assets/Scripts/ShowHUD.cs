using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class ShowHUD : MonoBehaviour
{
    [SerializeField] Image playerHP;
    [SerializeField] TMP_Text playerLvl;

    List<Figure> figures;

    private void Awake()
    {
        figures = GetComponentsInChildren<Figure>(true).ToList();


        foreach (var figure in figures)
        {
            figure.HpDisplay += OnHpDisplay;
            figure.LvlDisplay += OnLvlDisplay;
        }
    }
    void OnHpDisplay(float hp)
    {
        playerHP.fillAmount = hp;
    }
    void OnLvlDisplay(int lvl)
    {
        playerLvl.text = $"Lvl: {lvl.ToString()}";
    }
}
