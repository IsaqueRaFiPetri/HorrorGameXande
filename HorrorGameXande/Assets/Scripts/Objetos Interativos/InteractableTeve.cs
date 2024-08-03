using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTeve : InteractableObject
{
    bool isOn = false;
    public Light luz;
    Color randomColor;

    protected override void Interact()
    {
        if (!isOn)
        {
            isOn = true;
            luz.enabled = true;
        }
        else
        {
            isOn = false;
            luz.enabled = false;
        }
    }
    public void Update()
    {
        randomColor = new Color(Random.value, Random.value, Random.value);
        LuzChanger();
    }
    void LuzChanger()
    {
        luz.color = randomColor;
    }

}
