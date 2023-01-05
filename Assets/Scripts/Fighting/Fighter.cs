using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    NPC npc;

    private void Start()
    {
        npc = GetComponent<NPC>();
    }

    public void StartFight()
    {
        npc.gameManager.dialogueBubble.SetActive(false);

        npc.gameManager.player.GetComponent<PlayerMovement>().enabled = false;
        npc.gameManager.player.GetComponent<PlayerController>().enabled = false;
        npc.gameManager.player.AddComponent<PlayerFighting>();
    }
}
