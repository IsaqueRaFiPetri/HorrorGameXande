using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MigalhasCollector : MonoBehaviour
{
    public GameObject collectText;

    public AudioSource collectSound;

    private GameObject migalhas;

    private bool inReach;

    private GameObject gameLogic;


    void Start()
    {
        collectText.SetActive(false);

        inReach = false;

        gameLogic = GameObject.FindWithTag("GameLogic");

        migalhas = this.gameObject;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            collectText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            collectText.SetActive(false);
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("pickup"))
        {
            gameLogic.GetComponent<GameLogic>().pageCount += 1;
            collectSound.Play();
            collectText.SetActive(false);
            migalhas.SetActive(false);
            inReach = false;
        }


    }
}
