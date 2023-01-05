using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Asking))]

public class Seller : MonoBehaviour
{
    [SerializeField] private GameObject sellingPanel;

    NPC npc;

    private void Start()
    {
        npc = GetComponent<NPC>();
    }

    public void Sell()
    {
        if (npc.asking.question.options[npc.asking.choosen].ToLower() == "yes")
        {
            npc.gameManager.dialogueBubble.SetActive(false);

            sellingPanel.SetActive(true);
        }
        else
        {
            npc.speaking.Speak("See you next time");
        }
    }
}
