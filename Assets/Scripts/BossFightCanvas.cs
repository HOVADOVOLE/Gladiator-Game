using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossFightCanvas : MonoBehaviour
{
    [SerializeField] Button kill;
    [SerializeField] Button contine;
    [SerializeField] UIScriptableObject scene;

    private void Awake()
    {
        scene.buyGalia = true;
    }
    void Start()
    {
        kill.onClick.AddListener(Kill);
        contine.onClick.AddListener(Continue);
    }
    void Kill()
    {
        SceneManager.LoadScene(scene.lvlIndex);    
    }
    void Continue()
    {
        scene.lvlIndex = 1;
        SceneManager.LoadScene(scene.lvlIndex);
    }
}
