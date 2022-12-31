using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField] Button campfire;
    [SerializeField] Button continueJourney;

    [SerializeField] GameObject bonfire;

    [SerializeField] Canvas bossFight;
    [SerializeField] Canvas Atributes;

    [SerializeField] GameObject galia;

    Button camp;

    LevelLoader continueUrJour;
    List<Shop> shops;

    [SerializeField] UIScriptableObject scene;
    [SerializeField] PlayerScriptableObject player;

    void Start()
    {
        camp = campfire.GetComponent<Button>();
        Button cont = continueJourney.GetComponent<Button>();

        camp.onClick.AddListener(Campfire);
        cont.onClick.AddListener(ContinueJourney);

        if(scene.buyGalia == true)
            galia.SetActive(true);

        if(player.levlUp == true)
        {
            player.levlUp = false;
            Atributes.gameObject.SetActive(true);
        }
    }
    void Campfire()
    {
        SetShopActive(bonfire);
        camp.onClick.RemoveAllListeners();
    }
    void ContinueJourney()
    {
        if(scene.lvlIndex == 5)
        {
            this.gameObject.SetActive(false);
            bossFight.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(scene.lvlIndex);
        }
    }
    void SetShopActive(GameObject partShop)
    {
        if(partShop.gameObject.active == false)
            partShop.SetActive(true);
    }
}
