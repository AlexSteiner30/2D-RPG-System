using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject interactionGameObject;
    bool canInteract;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if(canInteract && Input.GetKey(KeyCode.Return))
        {
            interactionGameObject.GetComponent<InteractableObject>().interaction.Invoke();
            canInteract = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<InteractableObject>())
        {
            canInteract = true;

            interactionGameObject = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<InteractableObject>())
        {
            collision.gameObject.GetComponent<InteractableObject>().stopInteraction.Invoke();

            canInteract = false;

            interactionGameObject = null;
        }
    }
}
