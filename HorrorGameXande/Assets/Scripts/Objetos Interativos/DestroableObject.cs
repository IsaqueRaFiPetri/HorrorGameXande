using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroableObject : InteractableObject
{
    protected override void Interact()
    {
        PlayerInteraction.Instance.OnInteractionEffected.Invoke();
        Destroy(gameObject);

    }
}
