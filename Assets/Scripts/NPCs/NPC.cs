using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public UnityEvent[] events;
    public int eventCount = 0;

    public void InvokeEvents()
    {
        events[0].Invoke();
    }
}
