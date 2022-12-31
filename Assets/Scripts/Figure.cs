using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;

public class Figure : MonoBehaviour
{
    //TODO Zobrazení statù ze scriptable objectu real time(HUD)
    public event Action<float> HpDisplay;
    public event Action<int> LvlDisplay;

    protected float hp;
    public float Hp => hp;
    public float acualHp { get; set; }

    protected float dmg;
    public float Dmg => dmg;

    protected float defense;
    public float Defense => defense;

    protected int lvl;
    public int Lvl => lvl;


    protected float enXp;
    private void Update()
    {
        LvlDisplay?.Invoke(Lvl);
        HpDisplay?.Invoke(this.acualHp / this.Hp);
    }
    protected virtual void Awake() 
    {
       
    }
    protected void Show(int lvl, float hp)
    {
        LvlDisplay?.Invoke(lvl);
        HpDisplay?.Invoke(hp);
    }
}