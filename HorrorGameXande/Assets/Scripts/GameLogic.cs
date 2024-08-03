using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject counter;

    public int migalhasCount;

    public string tp;


    void Start()
    {
        migalhasCount = 0;

    }
    void Update()
    {
        counter.GetComponent<TMP_Text>().text = migalhasCount + "/4";

        if (migalhasCount == 4)
        {
            SceneManager.LoadScene(tp);
        }
    }
}