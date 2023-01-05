using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Speaking : MonoBehaviour
{
    GameManager gameManager;
    Button continueButton;
    Text text;

    private void Awake()
    {
        gameManager = GameObject.FindWithTag("Game Manager").GetComponent<GameManager>();
        text = gameManager.message;
        continueButton = gameManager.continueButton;
    }

    public void Speak(string msg)
    {
        gameManager.dialogueBubble.SetActive(true);

        text.text = null;

        StartCoroutine(SpeakCoroutine(msg));
    }

    private IEnumerator SpeakCoroutine(string msg)
    {
        continueButton.onClick.RemoveAllListeners();
        continueButton.onClick.AddListener(ContinueButton);

        for (int i = 0; i < msg.Length; i++)
        {
            text.text += msg[i];

            yield return new WaitForSeconds(.05f);
        }
    }

    private void ContinueButton()
    {
        StopAllCoroutines();

        if(++GetComponent<NPC>().eventCount < GetComponent<NPC>().events.Length)
        {
            GetComponent<NPC>().events[GetComponent<NPC>().eventCount].Invoke();
        }

        else
        {
            gameManager.dialogueBubble.SetActive(false);
        }
    }
}
