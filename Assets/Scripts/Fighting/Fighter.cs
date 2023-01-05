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
        npc.gameManager.inventory.SetActive(false);
    }
}
