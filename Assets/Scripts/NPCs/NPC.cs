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

        if (GetComponent<Asking>())
        {
            GetComponent<Asking>().StopAllCoroutines();
        }

        if (GetComponent<Seller>())
        {
            GetComponent<Seller>().StopAllCoroutines();
        }

        if (++eventCount < events.Length)
        {
            events[eventCount].Invoke();
        }

        else
        {
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().dialogueBubble.SetActive(false);
            eventCount = 0;
        }
    }
}
