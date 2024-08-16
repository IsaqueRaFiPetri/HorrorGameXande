using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableTeve : InteractableObject
{
    bool isOn = false;
    public GameObject tela;
    public Light luz;
    Color randomColor;

    protected override void Interact()
    {
        if (!isOn)
        {
            isOn = true;
            tela.SetActive(true);
        }
        else
        {
            isOn = false;
            tela.SetActive(true);
        }
    }
    public void Update()
    {
        randomColor = new Color(Random.value, Random.value, Random.value);
        luz.color = randomColor;
    }
}
