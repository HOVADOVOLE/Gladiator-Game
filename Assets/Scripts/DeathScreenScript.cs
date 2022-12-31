using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreenScript : MonoBehaviour
{
    [SerializeField] Button restart;
    [SerializeField] Button rageQuit;
    [SerializeField] PlayerScriptableObject player;
    [SerializeField] UIScriptableObject scene;
    // Start is called before the first frame update
    void Start()
    {
        restart.onClick.AddListener(Retry);
        rageQuit.onClick.AddListener(Menu);
    }

    void Retry()
    {
        scene.buyGalia = false;
        player.DeleteAtributes();
        player.UpdateAtributes();
        scene.lvlIndex = 1;
        SceneManager.LoadScene(1);
    }
    void Menu()
    {
        player.DeleteAtributes();
        SceneManager.LoadScene(0);
    }
}
