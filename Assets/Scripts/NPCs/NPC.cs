using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    [HideInInspector] public int eventCount = 0;
    public UnityEvent[] events;
     
    public void InvokeEvents()
    {
        events[0].Invoke();
    }

    public void ContinueButton()
    {
        GetComponent<Speaking>().StopAllCoroutines();
        GetComponent<Asking>().StopAllCoroutines();
        GetComponent<Seller>().StopAllCoroutines();

        if (++GetComponent<NPC>().eventCount < GetComponent<NPC>().events.Length)
        {
            GetComponent<NPC>().events[GetComponent<NPC>().eventCount].Invoke();
        }

        else
        {
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().dialogueBubble.SetActive(false);
        }
    }
}
