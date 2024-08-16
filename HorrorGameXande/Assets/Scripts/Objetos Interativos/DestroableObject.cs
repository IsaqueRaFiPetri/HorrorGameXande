using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroableObject : InteractableObject
{
    public AudioSource destroySound;
    protected override void Interact()
    {
        PlayerInteraction.Instance.OnInteractionEffected.Invoke();
        Destroy(gameObject);
        destroySound.Play();
    }
}
