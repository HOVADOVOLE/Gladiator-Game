using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWon : MonoBehaviour
{
    [SerializeField] float timeLenght;
    [SerializeField] GameObject uWon;

    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(timeLenght);

        uWon.gameObject.SetActive(true);
    }
}