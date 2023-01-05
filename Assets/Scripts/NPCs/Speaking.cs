using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Speaking : MonoBehaviour
{
    NPC npc;

    Button continueButton;
    Text text;

    private void Start()
    {
        npc = GetComponent<NPC>();

        text = npc.gameManager.message;
        continueButton = npc.gameManager.continueButton;
    }

    public void Speak(string msg)
    {
        npc.gameManager.dialogueBubble.SetActive(true);

        text.text = null;

        StartCoroutine(SpeakCoroutine(msg));
    }

    private IEnumerator SpeakCoroutine(string msg)
    {
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(GetComponent<NPC>().ContinueButton);

        for (int i = 0; i < msg.Length; i++)
        {
            text.text += msg[i];

            yield return new WaitForSeconds(.05f);
        }
    }
}
