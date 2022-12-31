using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowBonfire : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;
    [SerializeField] PlayerScriptableObject player;

    [SerializeField] float bonfireTimer;
    Button thisButton;
    private void Start()
    {
        thisButton = GetComponent<Button>();
    }
    void Update()
    {
        if(this.gameObject.active == true)
        {
            mainCanvas.gameObject.SetActive(false);
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(bonfireTimer);

        if(player.acualHp > player.hp * 0.66f)
        {
            player.acualHp = player.hp;
        }
        else
        {
            player.acualHp += player.hp / 3;
        }

        TurnOff();
    }

    void TurnOff()
    {
        this.gameObject.SetActive(false);
        mainCanvas.gameObject.SetActive(true);
        StopCoroutine(Timer());
    }
}
