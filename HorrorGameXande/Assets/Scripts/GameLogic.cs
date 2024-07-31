using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public GameObject counter;

    public int pageCount;

    public string tp;


    void Start()
    {
        pageCount = 0;

    }
    void Update()
    {
        counter.GetComponent<TMP_Text>().text = pageCount + "/4";

        if (pageCount == 8)
        {
            SceneManager.LoadScene(tp);
        }
    }
}