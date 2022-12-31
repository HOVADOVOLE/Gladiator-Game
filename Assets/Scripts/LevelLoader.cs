using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] UIScriptableObject scene;
    
    [SerializeField] Animator transition;
    [SerializeField] float transitionTime = 1f;
    [SerializeField] Enemy enemy;
    private void Start()
    {
        //enemy = FindObjectOfType<Enemy>();
    }
    // Update is called once per frame
    void Update()
    {
        if (enemy.acualHp < 1)
        {
            if(scene.lvlIndex == 5)
            {
                SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 2);
            }
            else
            {
                scene.lvlIndex++;
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
            }
        }    
        
    }

    private void LoadNextLevel(int indexOfLvl)
    {
        StartCoroutine(Loadlevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Loadlevel(int indelLevel)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(indelLevel);
    }
}
