using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] Button play;
    [SerializeField] Button credits;
    [SerializeField] Button exit;

    [SerializeField] Canvas creditsAnimations;
    [SerializeField] Canvas introAnimation;

    [SerializeField] UIScriptableObject scene;
    [SerializeField] PlayerScriptableObject player;

    [SerializeField] float transitionTime = 24f;

    // Start is called before the first frame update
    void Start()
    {
        player.UpdateAtributes();

        Button ply = play.GetComponent<Button>();
        Button crd = credits.GetComponent<Button>();
        Button ext = exit.GetComponent<Button>();

        ply.onClick.AddListener(Play);
        crd.onClick.AddListener(Credits);
        exit.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && creditsAnimations.gameObject.active == true)
        {
            creditsAnimations.gameObject.SetActive(false);
        }
    }

    void Play()
    {
        player.DeleteAtributes();
        player.UpdateAtributes();

        scene.buyGalia = false;
        scene.lvlIndex = 1;

        introAnimation.gameObject.SetActive(true);
        StartCoroutine(BetaTimer());
    }

    void Credits()
    {
        CreditsAnimation();
    }
    void Exit()
    {
        Application.Quit();
    }

    void CreditsAnimation()
    {
        creditsAnimations.gameObject.SetActive(true);
        StartCoroutine(Timer(24f, creditsAnimations));
    }
    IEnumerator Timer(float time, Canvas canvas)
    {

        while (time > 0f)
        {
            yield return new WaitForSeconds(1);
            time--;
        }

        canvas.gameObject.SetActive(false);
    }
    IEnumerator BetaTimer()
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene.lvlIndex);
        StartCoroutine(BetaTimer());
    }
}
