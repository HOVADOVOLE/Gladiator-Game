using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    [SerializeField] PlayerScriptableObject player;
    [SerializeField] List<Button> butonky;
    Canvas pause;

    //DELETE
    /*[SerializeField] Button continueBtn;
    [SerializeField] Button menuBtn;
    [SerializeField] Button exitBtn;*/

    private void Awake()
    {
        
    }
    void Start()
    {
        pause = GetComponentInChildren<Canvas>();

        butonky[0].onClick.AddListener(Continue);
        butonky[1].onClick.AddListener(ToMenu);
        butonky[2].onClick.AddListener(Exit);
        
        pause.gameObject.SetActive(false);
    }
    void Continue()
    {
        if (pause.gameObject.active)
        {
            Cursor.lockState = CursorLockMode.Locked;
            pause.gameObject.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            pause.gameObject.SetActive(true);
        }
    }
    void ToMenu()
    {
        player.DeleteAtributes();
        SceneManager.LoadScene(0);
    }
    void Exit()
    {
        player.DeleteAtributes();
        Application.Quit();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) && Player.movement == true)
        {
            Continue();
        }
        else if(Player.movement == false)
        {
            Cursor.lockState = CursorLockMode.None;
            pause.gameObject.SetActive(false);
        }
    }
}
