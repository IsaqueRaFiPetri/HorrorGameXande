using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MigalhasCollector : MonoBehaviour
{
    public GameObject collectText;

    public AudioSource collectSound;

    private GameObject migalhas;

    private GameObject gameLogic;

    void Start()
    {
        gameLogic = GameObject.FindWithTag("GameLogic");

        migalhas = this.gameObject;

    }
    void OnTriggerEnter()
    {
        gameLogic.GetComponent<GameLogic>().migalhasCount++;
        collectSound.Play();
        migalhas.SetActive(false);
    }
}
