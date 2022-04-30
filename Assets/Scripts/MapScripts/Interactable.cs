using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    // generic interactable script for treasure chests, enemies, etc.
    public float interactRadius = 2.5f;
    public Transform interactionTransform;

    bool isFocused = false;
    Transform player;

    bool interacted = false;

    void Update()
    {
        if (isFocused)
        {
            Debug.Log("focused");
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (!interacted && distance <= interactRadius)
            {
                Interact();
                interacted = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        isFocused = true;
        interacted = false;
        player = playerTransform;
    }

    public void OnDefocused()
    {
        isFocused = false;
        interacted = false;
        player = null;
    }

    // classes that inherit this base class will override this method
    public virtual void Interact()
    {

    }
}
