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
}
