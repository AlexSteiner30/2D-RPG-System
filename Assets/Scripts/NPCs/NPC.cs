using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(InteractableObject))]

public class NPC : MonoBehaviour
{
    [HideInInspector] public int eventCount = 0;
    [SerializeField] public UnityEvent[] events;

    [HideInInspector] public GameManager gameManager;
    [HideInInspector] public Speaking speaking;
    [HideInInspector] public Asking asking;
    [HideInInspector] public Seller seller;
    [HideInInspector] public Fighter fighter;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();

        TryGetComponent<Speaking>(out speaking);
        TryGetComponent<Asking>(out asking);
        TryGetComponent<Seller>(out seller);
        TryGetComponent<Fighter>(out fighter);
    }

    public void InvokeEvents()
    {
        events[0].Invoke();

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
    }

    public void StopInteraction()
    {
        StopAllCoroutines();

        eventCount = 0;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
    }

    public void ContinueButton()
    {
        speaking.StopAllCoroutines();

        if (asking)
        {
            asking.StopAllCoroutines();
        }

        if (seller)
        {
            seller.StopAllCoroutines();
        }

        if (++eventCount < events.Length)
        {
            events[eventCount].Invoke();
        }

        else
        {
            GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>().dialogueBubble.SetActive(false);

            StopInteraction();
        }
    }
}
