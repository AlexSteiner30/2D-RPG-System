using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject npc;
    bool canInteract;

    private void Update()
    {
        Interact();
    }

    private void Interact()
    {
        if(canInteract && Input.GetKey(KeyCode.E))
        {
            npc.GetComponent<NPC>().InvokeEvents();
            canInteract = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<NPC>())
        {
            canInteract = true;

            npc = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<NPC>())
        {
            canInteract = false;

            npc = null;
        }
    }
}
